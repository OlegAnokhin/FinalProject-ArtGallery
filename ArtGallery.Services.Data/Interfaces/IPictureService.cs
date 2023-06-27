namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.Picture;

    /// <summary>
    /// Услуга за управление на картини
    /// </summary>

    public interface IPictureService
    {
        /// <summary>
        /// Добавяне на категории към картината
        /// </summary>
        /// <returns></returns>
        Task<PictureModel> GetCategoriesForAddNewPictureAsync();

        /// <summary>
        /// Добавяне на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>
        Task AddAsync(PictureModel model);

        /// <summary>
        /// Изтриване на картина
        /// </summary>
        /// <param name="id">Идентификатор на картина</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Промяна на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>
        Task EditAsync(PictureModel model, int id);

        /// <summary>
        /// Преглед на всички картини
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PictureModel>> GetAllAnimalsAsync();

        /// <summary>
        /// Преглед на картина
        /// </summary>
        /// <param name="id">Идентификатор на картина</param>
        /// <returns></returns>
        Task<PictureModel> GetPictureByIdAsync(int id);
    }
}
