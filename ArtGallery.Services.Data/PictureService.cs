using ArtGallery.Web.ViewModels.Home;

namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using ArtGallery.Data;
    using ArtGallery.Data.Models;
    using Web.ViewModels.Picture;
    using ArtGallery.Services.Data.Models.Picture;
    using ArtGallery.Web.ViewModels.Picture.Enums;

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
        ///// <summary>
        ///// Достъп до база данни
        ///// </summary>
        //private readonly IRepository repo;

        ///// <summary>
        ///// Инжектиране на зависимост
        ///// </summary>
        ///// <param name="_repo">Достъп до база данни</param>
        //public PictureService(IRepository _repo)
        //{
        //    repo = _repo;
        //}

        /// <summary>
        /// Добавяне на последно качените картини
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IndexViewModel>> LastThreePicturesAsync()
        {
            IEnumerable<IndexViewModel> lastThreePictures = await this.dbContext
                .Pictures
                .OrderByDescending(p => p.CreatedOn)
                .Take(3)
                .Select(p => new IndexViewModel()
                {
                    Id = p.Id,
                    Title = p.Name,
                    ImageUrl = p.ImageAddress
                })
                .ToArrayAsync();

            return lastThreePictures;
        }

        /// <summary>
            /// Добавяне на категории към картината
            /// </summary>
            /// <returns></returns>
            public async Task<PictureModel> GetCategoriesForAddNewPictureAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new PictureSelectCategoryModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            var model = new PictureModel()
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
        public async Task AddAsync(AddPictureViewModel model)
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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// Изтриване на картина
        ///// </summary>
        ///// <param name="id">Идентификатор на картина</param>
        ///// <returns></returns>
        //public async Task DeleteAsync(int id)
        //{
        //    await dbContext.DeleteAsync<Picture>(id);
        //    await dbContext.SaveChangesAsync();
        //}

        /// <summary>
        /// Промяна на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>

        public async Task EditAsync(PictureModel model, int id)
        {
            var entity = await dbContext.Pictures.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Невалиден идентификатор", nameof(model.Id));
            }
            entity.Name = model.Name;
            entity.Size = model.Size;
            entity.Material = model.Material;
            entity.ImageAddress = model.ImageAddress;
            entity.ImageBase = model.ImageBase;
            entity.Description = model.Description;
            entity.CreatedOn = model.Date;
            entity.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Прегед на всички картини
        /// </summary>
        /// <param name="id">Идентификатор на картина</param>
        /// <returns></returns>
        public async Task<IEnumerable<PictureModel>> GetAllAnimalsAsync()
        {
            return await dbContext
                .Pictures
                .Select(p => new PictureModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Size = p.Size,
                    Material = p.Material,
                    ImageAddress = p.ImageAddress,
                    ImageBase = p.ImageBase,
                    Description = p.Description,
                    Date = p.CreatedOn,
                    Category = p.Category.Name
                })
                .Where(p => p.Category == "Animals")
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Пергед на картина
        /// </summary>
        /// <param name="id">Идентификатор на картина</param>
        /// <returns></returns>
        public async Task<PictureModel?>? GetPictureByIdAsync(int id)
        {
            return await dbContext.Pictures
                .Where(p => p.Id == id)
                .Select(p => new PictureModel
                {
                    Name = p.Name,
                    Size = p.Size,
                    Material = p.Material,
                    ImageAddress = p.ImageAddress,
                    ImageBase = p.ImageBase,
                    Description = p.Description,
                    Date = p.CreatedOn,
                    CategoryId = p.CategoryId
                }).FirstOrDefaultAsync();
        }

    }
}