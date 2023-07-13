using ArtGallery.Data.Models;

namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Data;
    using Web.ViewModels.ArtEvent;
    using Interfaces;

    public class ArtEventService : IArtEventService
    {
        private readonly ArtGalleryDbContext context;

        public ArtEventService(ArtGalleryDbContext context)
        {
            this.context = context;
        }

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

        public async Task AddArtEventAsync(ArtEventFormModel model)
        {
            var artEvent = new ArtEvent
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
    }
}