namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using ArtGallery.Data;
    using Web.ViewModels.Picture;

    public class CategoryService : ICategoryService
    {
        private readonly ArtGalleryDbContext dbContext;

        public CategoryService(ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
    }
}