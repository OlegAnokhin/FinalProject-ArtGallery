﻿namespace ArtGallery.Services.Data.Interfaces
{
    using ArtGallery.Services.Data.Models.Picture;
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
        Task<IEnumerable<IndexViewModel>> LastThreePicturesAsync();

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
        Task AddAsync(AddPictureViewModel model);

        /// <summary>
        /// Услуга по търсене и подреждане
        /// </summary>
        /// <param name="model">Параметри за търсене и подреждане</param>
        /// <returns></returns>
        Task<AllPicturesFilteredAndPagedServiceModel> AllAsync(AllPictureQueryModel model);

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
