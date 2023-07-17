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

        /// <summary>
        /// Взимане на обучение
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        public async Task<AllArtEventViewModel> GetArtEventByIdAsync(int artEventId)
        {
            return await this.context.ArtEvents
                .Where(e => e.Id == artEventId)
                .Select(e => new AllArtEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    ImageAddress = e.ImageAddress,
                    Start = e.Start
                }).FirstAsync();
        }

        /// <summary>
        /// Взимане на списък с обучения на потребителя
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <returns></returns>
        public async Task<List<JoinedArtEventsViewModel>> GetJoinedArtEventsAsync(string userId)
        {
            return await this.context.ArtEventParticipants
                .Where(e => e.ParticipantId == userId)
                .Select(e => new JoinedArtEventsViewModel
                {
                    Id = e.ArtEventId,
                    Name = e.ArtEvent.Name,
                    ImageAddress = e.ArtEvent.ImageAddress,
                    Start = e.ArtEvent.Start,
                    Place = e.ArtEvent.Place,
                    Description = e.ArtEvent.Description
                }).ToListAsync();
        }

        /// <summary>
        /// Добавяне на потребител към обучението
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <param name="model">Модел на обучението</param>
        /// <returns></returns>
        public async Task JoinToArtEventAsync(string userId, AllArtEventViewModel model)
        {
            if (!await context.ArtEventParticipants.AnyAsync(e =>
                    e.ParticipantId == userId && e.ArtEventId == model.Id))
            {
                await context.ArtEventParticipants.AddAsync(new ArtEventParticipant
                {
                    ParticipantId = userId,
                    ArtEventId = model.Id
                });
                await context.SaveChangesAsync();
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
            var participant = await context.ArtEventParticipants
                .FirstOrDefaultAsync(e => e.ParticipantId == userId && e.ArtEventId == model.Id);
            if (participant != null)
            {
                context.ArtEventParticipants.Remove(participant);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetCountOfParticipantAsync(int eventId)
        {
            //var artEvent = await context.ArtEventParticipants
            //    .FirstAsync(e => e.ArtEventId == eventId);

            //if (artEvent != null)
            //{
            //    //var count = this.context.ArtEventParticipants.Count();
            //    var count = artEvent.ParticipantId.Count();
            //    return count;
            //}
            var count = context.ArtEventParticipants
                .Where(e => e.ArtEventId == eventId)
                .Count();

            return count;
        }
    }
}