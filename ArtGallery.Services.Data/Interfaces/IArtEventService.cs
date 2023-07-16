namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.ArtEvent;

    /// <summary>
    /// Услуга за управление на обучението
    /// </summary>
    public interface IArtEventService
    {
        /// <summary>
        /// Преглед на всички обучения
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllArtEventViewModel>> GetAllArtEventsAsync();

        /// <summary>
        /// Добавяне на обучението
        /// </summary>
        /// <param name="model">Модел за попълване</param>
        /// <returns></returns>
        Task AddArtEventAsync(ArtEventFormModel model);

        /// <summary>
        /// Проверка за съществуване
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        Task<bool> ExistsByIdAsync(int artEventId);

        /// <summary>
        /// Преглед на обучението
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        Task<DetaisArtEventViewModel> GetArtEventDetailsAsync(int artEventId);

        /// <summary>
        /// Изтриване на обучението
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        Task DeleteArtEventAsync(int artEventId);

        
    }
}
