namespace ArtGallery.Services.Data.Interfaces
{
    using Models.Picture;
    using Web.ViewModels.Home;
    using Web.ViewModels.Picture;

    /// <summary>
    /// Услуга за управление на картини
    /// </summary>

    public interface IPictureService
    {
        /// <summary>
        /// Зарежда последно качените картини
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PictureInfo>> LastPicturesAsync(int pictureCount);

        /// <summary>
        /// Добавяне на категории към картината
        /// </summary>
        /// <returns></returns>
        Task<AddAndEditPictureViewModel> GetCategoriesForAddNewPictureAsync();

        /// <summary>
        /// Добавяне на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>
        Task AddAsync(AddAndEditPictureViewModel model);

        /// <summary>
        /// Услуга по търсене и подреждане
        /// </summary>
        /// <param name="model">Параметри за търсене и подреждане</param>
        /// <returns></returns>
        Task<AllPicturesFilteredAndPagedServiceModel> AllAsync(AllPictureQueryModel model);

        /// <summary>
        /// Взимане на детайли за картината
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <returns></returns>
        Task<DetailsPictureViewModel> GetDetailsByIdAsync(int pictureId);

        /// <summary>
        /// Проверяване дали има картина с този идентификатор
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <returns></returns>
        Task<bool> ExistByIdAsync(int pictureId);

        /// <summary>
        /// Промяна на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>
        Task<AddAndEditPictureViewModel> GetPictureForEditAsync(int pictureId);

        /// <summary>
        /// Вземане на картина за редактиране
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <param name="model">Модел на редактиране</param>
        /// <returns></returns>
        Task EditPictureByIdAsync(int pictureId, AddAndEditPictureViewModel model);

        /// <summary>
        /// Изтриване на картина
        /// </summary>
        /// <param name="id">Идентификатор на картина</param>
        /// <returns></returns>
        Task DeletePictureByIdAsync(int pictureId);
    }
}