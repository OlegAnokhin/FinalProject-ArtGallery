// ReSharper disable ReplaceWithSingleCallToCount

using ArtGallery.Web.ViewModels.Home;

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
        private readonly ArtGalleryDbContext dbContext;

        /// <summary>
        /// Инжектиране на зависимост
        /// </summary>
        /// <param name="dbContext">Достъп до база данни</param>
        public ArtEventService(ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Прeглед на всички събития
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllArtEventViewModel>> GetAllArtEventsAsync()
        {
            return await dbContext.ArtEvents
                .Select(e => new AllArtEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    ImageAddress = e.ImageAddress,
                    Start = e.Start
                })
                .ToListAsync();
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
                Description = model.Description
            };

            await dbContext.ArtEvents.AddAsync(artEvent);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Проверка за съществуване
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        public async Task<bool> ExistsByIdAsync(int artEventId)
        {
            return await this.dbContext.ArtEvents
                .AnyAsync(a => a.Id == artEventId);
        }

        /// <summary>
        /// Преглед на обучението
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        public async Task<DetaisArtEventViewModel> GetArtEventDetailsAsync(int artEventId)
        {
            ArtEvent artEvent = await this.dbContext.ArtEvents
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
            ArtEvent artEvent = await this.dbContext.ArtEvents
                .FirstAsync(a => a.Id == artEventId);

            this.dbContext.ArtEvents.Remove(artEvent);
            await this.dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Взимане на обучение
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        public async Task<AllArtEventViewModel> GetArtEventByIdAsync(int artEventId)
        {
            return await this.dbContext.ArtEvents
                .Where(e => e.Id == artEventId)
                .Select(e => new AllArtEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    ImageAddress = e.ImageAddress,
                    Start = e.Start
                })
                .FirstAsync();
        }

        /// <summary>
        /// Взимане на списък с обучения на потребителя
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <returns></returns>
        public async Task<List<JoinedArtEventsViewModel>> GetJoinedArtEventsAsync(string userId)
        {
            return await this.dbContext.ArtEventParticipants
                .Where(e => e.ParticipantId == userId)
                .Select(e => new JoinedArtEventsViewModel
                {
                    Id = e.ArtEventId,
                    Name = e.ArtEvent.Name,
                    ImageAddress = e.ArtEvent.ImageAddress,
                    Start = e.ArtEvent.Start,
                    Place = e.ArtEvent.Place,
                    Description = e.ArtEvent.Description
                })
                .ToListAsync();
        }

        /// <summary>
        /// Добавяне на потребител към обучението
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <param name="model">Модел на обучението</param>
        /// <returns></returns>
        public async Task JoinToArtEventAsync(string userId, AllArtEventViewModel model)
        {
            if (!await dbContext.ArtEventParticipants.AnyAsync(e =>
                    e.ParticipantId == userId && e.ArtEventId == model.Id))
            {
                await dbContext.ArtEventParticipants.AddAsync(new ArtEventParticipant
                {
                    ParticipantId = userId,
                    ArtEventId = model.Id
                });
                await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Изтриване на потребител от обучението
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <param name="model">Модел на обучението</param>
        /// <returns></returns>
        public async Task LeaveFromArtEventAsync(string userId, AllArtEventViewModel model)
        {
            var participant = await dbContext.ArtEventParticipants
                .FirstOrDefaultAsync(e => e.ParticipantId == userId && e.ArtEventId == model.Id);
            if (participant != null)
            {
                dbContext.ArtEventParticipants.Remove(participant);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetCountOfParticipantAsync(int eventId)
        {
            return await dbContext.ArtEventParticipants
                .Where(e => e.ArtEventId == eventId)
                .CountAsync();
        }

        public async Task<IndexViewModel> LastArtEventAsync()
        {
            var lastArtEvent = await this.dbContext.ArtEvents
                .OrderByDescending(e => e.Start)
                .Select(e => new IndexViewModel()
                {
                    ArtEventTitle = e.Name,
                    ArtEventImageUrl = e.ImageAddress
                })
                .FirstAsync();

            return lastArtEvent;
        }
    }
}