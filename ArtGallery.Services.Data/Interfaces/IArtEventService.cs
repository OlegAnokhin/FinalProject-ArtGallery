namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.ArtEvent;

    public interface IArtEventService
    {
         Task<IEnumerable<AllArtEventViewModel>> GetAllArtEventsAsync();

        Task AddArtEventAsync(ArtEventFormModel model);


    }
}
