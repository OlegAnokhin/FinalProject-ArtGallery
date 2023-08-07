namespace ArtGallery.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using ArtGallery.Data;
    using Data.Interfaces;
    using static DatabaseSeeder;

    public class CategoryServiceTests
    {
        private DbContextOptions<ArtGalleryDbContext> dbOptions;
        private ArtGalleryDbContext dbContext;
        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ArtGalleryDbContext>()
                .UseInMemoryDatabase("ArtGalleryInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ArtGalleryDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategories()
        {
            var result = await this.categoryService.AllCategoriesAsync();
            var resultCount = result.Count();

            Assert.That(resultCount, Is.EqualTo(4));
        }

        [Test]
        public async Task AllCategoryNamesAsync_ShouldReturnAllCategoryNames()
        {
            IEnumerable<string> expectedNames = new List<string> { "Животни", "Хора", "Къщи", "Пейзаж" };
            IEnumerable<string> actualNames;

            actualNames = await this.categoryService.AllCategoryNamesAsync();

            CollectionAssert.AreEquivalent(expectedNames, actualNames);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            int existingCategoryId = 1;
            bool result = await this.categoryService.ExistsByIdAsync(existingCategoryId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            int existingCategoryId = 666;
            bool result = await this.categoryService.ExistsByIdAsync(existingCategoryId);

            Assert.IsFalse(result);
        }
    }
}