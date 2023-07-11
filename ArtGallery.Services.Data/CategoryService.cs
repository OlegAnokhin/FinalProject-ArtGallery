namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using ArtGallery.Data;
    using Web.ViewModels.Picture;

    /// <summary>
    /// Услуга за управление на категории
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Достъп до база данни
        /// </summary>
        private readonly ArtGalleryDbContext dbContext;

        /// <summary>
        /// Инжектиране на зависимост
        /// </summary>
        /// <param name="dbContext">Достъп до база данни</param>
        public CategoryService(ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Взимане на всички категории
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PictureSelectCategoryModel>> AllCategoriesAsync()
        {
            IEnumerable<PictureSelectCategoryModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new PictureSelectCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();
            return allCategories;
        }

        /// <summary>
        /// Взимане на имената на категории
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext 
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();
            return allNames;
        }

        /// <summary>
        /// Проверяване дали има категория
        /// </summary>
        /// <param name="id">Идентификатор на категорията</param>
        /// <returns></returns>
        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);
            return result;
        }
    }
}