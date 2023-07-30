namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Models.Picture;
    using ArtGallery.Data;
    using ArtGallery.Data.Models;
    using Web.ViewModels.Home;
    using Web.ViewModels.Comment;
    using Web.ViewModels.Picture;
    using Web.ViewModels.Picture.Enums;

    /// <summary>
    /// Услуга за управление на събития
    /// </summary>
    public class PictureService : IPictureService
    {
        /// <summary>
        /// Достъп до база данни
        /// </summary>
        private readonly ArtGalleryDbContext dbContext;

        /// <summary>
        /// Инжектиране на зависимост
        /// </summary>
        /// <param name="dbContext">Достъп до база данни</param>
        public PictureService(ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Добавяне на последно качените картини
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IndexViewModel>> LastPicturesAsync(int pictureCount)
        {
            IEnumerable<IndexViewModel> lastThreePictures = await this.dbContext
                .Pictures
                .OrderByDescending(p => p.CreatedOn)
                .Take(pictureCount)
                .Select(p => new IndexViewModel()
                {
                    Id = p.Id,
                    PictureTitle = p.Name,
                    PictureImageUrl = p.ImageAddress
                })
                .ToArrayAsync();

            return lastThreePictures;
        }

        /// <summary>
            /// Добавяне на категории към картината
            /// </summary>
            /// <returns></returns>
            public async Task<AddAndEditPictureViewModel> GetCategoriesForAddNewPictureAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new PictureSelectCategoryModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            var model = new AddAndEditPictureViewModel()
            {
                Categories = categories
            };
            return model;
        }
        /// <summary>
        /// Добавяне на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>
        public async Task AddAsync(AddAndEditPictureViewModel model)
        {
            Picture entity = new Picture()
            {
                Name = model.Name,
                Size = model.Size,
                Material = model.Material,
                ImageAddress = model.ImageAddress,
                ImageBase = model.ImageBase,
                Description = model.Description,
                CategoryId = model.CategoryId
            };
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Услуга по търсене и подреждане
        /// </summary>
        /// <param name="model">Параметри за търсене и подреждане</param>
        /// <returns></returns>
        public async Task<AllPicturesFilteredAndPagedServiceModel> AllAsync(AllPictureQueryModel model)
        {
            IQueryable<Picture> pictureQuery = this.dbContext
                .Pictures
                .AsQueryable();

            if(!string.IsNullOrWhiteSpace(model.Category))
            {
                pictureQuery = pictureQuery
                    .Where(p => p.Category.Name == model.Category);
            }

            if(!string.IsNullOrWhiteSpace(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";
                pictureQuery = pictureQuery
                    .Where(p => EF.Functions.Like(p.Name, wildCard));
            }

            pictureQuery = model.PictureSorting switch
            {
                PictureSorting.Newest => pictureQuery
                .OrderByDescending(p => p.CreatedOn),
                PictureSorting.Oldest => pictureQuery
                .OrderBy(p => p.CreatedOn),
                _ => pictureQuery
                .OrderBy(p => p.Id)
            };

            IEnumerable<AllPictureViewModel> allPictures = await pictureQuery
                .Skip((model.CurrentPage - 1) * model.PicturesPerPage)
                .Take(model.PicturesPerPage)
                .Select(p => new AllPictureViewModel
                {
                    Id = p.Id,
                    ImageAddress = p.ImageAddress,
                    Name = p.Name
                })
                .ToArrayAsync();
            int totalPictures = pictureQuery.Count();

            return new AllPicturesFilteredAndPagedServiceModel()
            {
                TotalPicturesCount = totalPictures,
                Pictures = allPictures
            };
        }

        /// <summary>
        /// Вземане на картина за редактиране
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <param name="model">Модел на редактиране</param>
        /// <returns></returns>
        public async Task EditPictureByIdAsync(int pictureId, AddAndEditPictureViewModel model)
        {
            Picture picture = await this.dbContext
                .Pictures
                .FirstAsync(p => p.Id == pictureId);

            picture.Name = model.Name;
            picture.Size = model.Size;
            picture.Material = model.Material;
            picture.ImageAddress = model.ImageAddress;
            picture.ImageBase = model.ImageBase;
            picture.CategoryId = model.CategoryId;
            picture.Description = model.Description;

            await this.dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Показване на детайли на картината
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<DetailsPictureViewModel> GetDetailsByIdAsync(int pictureId)
        {
            Picture? picture = await this.dbContext
                .Pictures
                .Include(p => p.Category)
                .Include(pc => pc.PictureComments)
                .FirstAsync(p => p.Id == pictureId);

            var comments = await this.dbContext
                .Comments
                .Where(p => p.PictureId == pictureId)
                .Select(c => new CommentViewModel()
                {
                    CommentId = c.CommentId,
                    PictureId = pictureId,
                    Username = c.Username,
                    Content = c.Content
                }).ToArrayAsync();

            return new DetailsPictureViewModel()
            {
                Id = picture.Id,
                Name = picture.Name,
                Size = picture.Size,
                Material = picture.Material,
                ImageAddress = picture.ImageAddress,
                ImageBase = picture.ImageBase,
                Category = picture.Category.Name,
                Description = picture.Description,
                Date = picture.CreatedOn,
                Comments = comments
            };
        }

        /// <summary>
        /// Проверяване дали има картина с този идентификатор
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <returns></returns>
        public async Task<bool> ExistByIdAsync(int pictureId)
        {
            bool result = await this.dbContext
                .Pictures
                .AnyAsync(p => p.Id == pictureId);

            return result;
        }

        /// <summary>
        /// Промяна на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>

        public async Task<AddAndEditPictureViewModel> GetPictureForEditAsync(int pictureId)
        {
            Picture picture = await this.dbContext
                .Pictures
                .Include(p => p.Category)
                .FirstAsync(p => p.Id == pictureId);
            
            return new AddAndEditPictureViewModel
            {
                Name = picture.Name,
                Size = picture.Size,
                Material = picture.Material,
                ImageAddress = picture.ImageAddress,
                ImageBase = picture.ImageBase,
                CategoryId = picture.CategoryId,
                Description = picture.Description,
                CreatedOn = picture.CreatedOn
            };
        }

        /// <summary>
        /// Изтриване на картина
        /// </summary>
        /// <param name="id">Идентификатор на картина</param>
        /// <returns></returns>
        public async Task DeletePictureByIdAsync(int pictureId)
        {
            Picture picture = await this.dbContext
                .Pictures
                .FirstAsync(p => p.Id == pictureId);

            this.dbContext.Pictures.Remove(picture);
            await this.dbContext.SaveChangesAsync();
        }
    }
}