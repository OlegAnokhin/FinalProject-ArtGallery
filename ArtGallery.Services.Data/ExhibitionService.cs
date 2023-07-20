namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Data;
    using ArtGallery.Data.Models;
    using Web.ViewModels.Exhibition;
    using Interfaces;

    /// <summary>
    /// Услуга за управление на събития
    /// </summary>
    public class ExhibitionService : IExhibitionService
    {
        /// <summary>
        /// Достъп до база данни
        /// </summary>
        private readonly ArtGalleryDbContext dbContext;

        /// <summary>
        /// Инжектиране на зависимост
        /// </summary>
        /// <param name="dbContext">Достъп до база данни</param>
        public ExhibitionService(ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Прeглед на всички събития
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllExhibitionsViewModel>> GetAllAsync()
        {
            return await this.dbContext.Exhibitions
                .Select(e => new AllExhibitionsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    ImageUrl = e.ImageUrl,
                    Place = e.Place
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }

        /// <summary>
        /// Добавяне на събитие
        /// </summary>
        /// <param name="model">Данни за събитие</param>
        /// <returns></returns>
        public async Task AddAsync(ExhibitionFormModel model)
        {
            Exhibition exhibition = new Exhibition
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Start = model.Start,
                End = model.End,
                Place = model.Place,
                Description = model.Description
            };
            await this.dbContext.Exhibitions.AddAsync(exhibition);
            await this.dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Проверка за съществуване
        /// </summary>
        /// <param name="exhibitionId">Идентификатор на изложбата</param>
        /// <returns></returns>
        public async Task<bool> ExistsByIdAsync(int exhibitionId)
        {
            bool result = await this.dbContext.Exhibitions
                .AnyAsync(e => e.Id == exhibitionId);
            return result;
        }

        /// <summary>
        /// Преглед на изложбата
        /// </summary>
        /// <param name="id">Идентификатор на изложбата</param>
        /// <returns></returns>
        public async Task<DetailsExhibitionsViewModel> GetExhibitionDetailsAsync(int id)
        {
            Exhibition exhibition = await this.dbContext
                .Exhibitions
                .FirstAsync(e => e.Id == id);

            return new DetailsExhibitionsViewModel
            {
                Id = exhibition.Id,
                Name = exhibition.Name,
                ImageUrl = exhibition.ImageUrl,
                Start = exhibition.Start,
                Place = exhibition.Place,
                End = exhibition.End,
                Description = exhibition.Description
            };
        }

        /// <summary>
        /// Изтриване на събитие
        /// </summary>
        /// <param name="id">Идентификатор на събитие</param>
        /// <returns></returns>
        public async Task DeleteExhibitionAsync(int id)
        {
            Exhibition exhibition = await this.dbContext
                .Exhibitions
                .FirstAsync(e => e.Id == id);

            this.dbContext.Exhibitions.Remove(exhibition);
            await this.dbContext.SaveChangesAsync();
        }
    }
}