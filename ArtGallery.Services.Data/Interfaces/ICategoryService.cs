﻿namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.Picture;

    public interface ICategoryService
    {
        Task<IEnumerable<PictureSelectCategoryModel>> AllCategoriesAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}