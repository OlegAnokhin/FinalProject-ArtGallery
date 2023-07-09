namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.Exhibition;

    /// <summary>
    /// Услуга за управление на изложбата
    /// </summary>
    public interface IExhibitionService
    {
        /// <summary>
        /// Преглед на всички изложби
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AllExhibitionsViewModel>> GetAllAsync();

        ///// <summary>
        ///// Добавяне на изложбата
        ///// </summary>
        ///// <param name="model">Данни за изложбата</param>
        ///// <returns></returns>
        //Task AddAsync(AddExhibitionViewModel model);

        ///// <summary>
        ///// Изтриване на изложбата
        ///// </summary>
        ///// <param name="id">Идентификатор на изложбата</param>
        ///// <returns></returns>
        //Task DeleteAsync(int id);

        ///// <summary>
        ///// Промяна на изложбата
        ///// </summary>
        ///// <param name="model">Данни за изложбата</param>
        ///// <returns></returns>
        //Task UpdateAsync(AddExhibitionViewModel model);

        ///// <summary>
        ///// Преглед на изложбата
        ///// </summary>
        ///// <param name="id">Идентификатор на изложбата</param>
        ///// <returns></returns>
        //Task<AddExhibitionViewModel> GetEventAsync(int id);
    }
}