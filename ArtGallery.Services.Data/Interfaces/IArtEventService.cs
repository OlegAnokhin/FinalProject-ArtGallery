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

        /// <summary>
        /// Взимане на обучение
        /// </summary>
        /// <param name="artEventId">Идентификатор на обучението</param>
        /// <returns></returns>
        Task<AllArtEventViewModel> GetArtEventByIdAsync(int artEventId);

        /// <summary>
        /// Взимане на списък с обучения на потребителя
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <returns></returns>
        Task<List<JoinedArtEventsViewModel>> GetJoinedArtEventsAsync(string userId);

        /// <summary>
        /// Добавяне на потребител към обучението
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <param name="model">Модел на обучението</param>
        /// <returns></returns>
        Task JoinToArtEventAsync(string userId, AllArtEventViewModel model);

        /// <summary>
        /// Изтриване на потребител от обучението
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <param name="model">Модел на обучението</param>
        /// <returns></returns>
        Task LeaveFromArtEventAsync(string userId, AllArtEventViewModel model);

        Task<int> GetCountOfParticipantAsync(int eventId);
    }
}
