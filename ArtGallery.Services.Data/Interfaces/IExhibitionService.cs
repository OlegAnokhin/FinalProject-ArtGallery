namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.Exhibition;

    /// <summary>
    /// Услуга за управление на изложбата
    /// </summary>
    public interface IExhibitionService
    {
        /// <summary>
        /// Добавяне на изложбата
        /// </summary>
        /// <param name="model">Данни за изложбата</param>
        /// <returns></returns>
        Task AddAsync(ExhibitionModel model);

        /// <summary>
        /// Изтриване на изложбата
        /// </summary>
        /// <param name="id">Идентификатор на изложбата</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Промяна на изложбата
        /// </summary>
        /// <param name="model">Данни за изложбата</param>
        /// <returns></returns>
        Task UpdateAsync(ExhibitionModel model);

        /// <summary>
        /// Преглед на всички изложби
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExhibitionModel>> GetAllAsync();

        /// <summary>
        /// Преглед на изложбата
        /// </summary>
        /// <param name="id">Идентификатор на изложбата</param>
        /// <returns></returns>
        Task<ExhibitionModel> GetEventAsync(int id);
    }
}