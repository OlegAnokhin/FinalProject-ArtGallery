namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.Picture;

    public interface ICategoryService
    {
        /// <summary>
        /// Взимане на всички категории
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PictureSelectCategoryModel>> AllCategoriesAsync();

        /// <summary>
        /// Проверяване дали има категория
        /// </summary>
        /// <param name="id">Идентификатор на категорията</param>
        /// <returns></returns>
        Task<bool> ExistsByIdAsync(int id);

        /// <summary>
        /// Взимане на имената на категории
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}