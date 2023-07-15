namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Data;
    using ArtGallery.Data.Models;
    using Web.ViewModels.ArtEvent;
    using Interfaces;

    /// <summary>
    /// Услуга за управление на обучения
    /// </summary>
    public class ArtEventService : IArtEventService
    {
        /// <summary>
        /// Достъп до база данни
        /// </summary>
        private readonly ArtGalleryDbContext context;

        /// <summary>
        /// Инжектиране на зависимост
        /// </summary>
        /// <param name="context">Достъп до база данни</param>
        public ArtEventService(ArtGalleryDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Прeглед на всички събития
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllArtEventViewModel>> GetAllArtEventsAsync()
        {
            return await context.ArtEvents
                .Select(e => new AllArtEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    ImageAddress = e.ImageAddress,
                    Start = e.Start
                }).ToListAsync();
        }

        /// <summary>
        /// Добавяне на обучението
        /// </summary>
        /// <param name="model">Данни за събитие</param>
        /// <returns></returns>
        public async Task AddArtEventAsync(ArtEventFormModel model)
        {
            ArtEvent artEvent = new ArtEvent
            {
                Name = model.Name,
                Start = model.Start,
                ImageAddress = model.ImageAddress,
                Place = model.Place,
                Description = model.Description,
            };
            await context.ArtEvents.AddAsync(artEvent);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Проверка за съществуване
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        public async Task<bool> ExistsByIdAsync(int artEventId)
        {
            bool result = await this.context.ArtEvents
                .AnyAsync(a => a.Id == artEventId);
            return result;
        }

        /// <summary>
        /// Преглед на обучението
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        public async Task<DetaisArtEventViewModel> GetArtEventDetailsAsync(int artEventId)
        {
            ArtEvent artEvent = await this.context
                .ArtEvents
                .FirstAsync(a => a.Id == artEventId);

            return new DetaisArtEventViewModel
            {
                Id = artEvent.Id,
                Name = artEvent.Name,
                ImageAddress = artEvent.ImageAddress,
                Start = artEvent.Start,
                Place = artEvent.Place,
                Description = artEvent.Description
            };
        }

        /// <summary>
        /// Изтриване на обучението
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        public async Task DeleteArtEventAsync(int artEventId)
        {
            ArtEvent artEvent = await this.context
                .ArtEvents
                .FirstAsync(a => a.Id == artEventId);

            this.context.ArtEvents.Remove(artEvent);
            await this.context.SaveChangesAsync();
        }
    }
}