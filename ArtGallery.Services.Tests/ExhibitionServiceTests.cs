namespace ArtGallery.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using Data;
    using ArtGallery.Data;
    using Data.Interfaces;
    using Web.ViewModels.Exhibition;
    using static DatabaseSeeder;

    public class ExhibitionServiceTests
    {
        private DbContextOptions<ArtGalleryDbContext> dbOptions;
        private ArtGalleryDbContext dbContext;
        private IExhibitionService exhibitionService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ArtGalleryDbContext>()
                .UseInMemoryDatabase("ArtGalleryInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ArtGalleryDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.exhibitionService = new ExhibitionService(this.dbContext);
        }

        [Test]
        public async Task GetAllAsyncShouldTakeAllExhibitions()
        {
            var result = await this.exhibitionService.GetAllAsync();
            var resultCount = result.Count();

            Assert.That(resultCount, Is.EqualTo(2));
        }

        [Test]
        public async Task AddAsyncShouldAddNewExhibitionAndIncreaseAllCount()
        {
            var newExhibition = new ExhibitionFormModel()
            {
                Name = "Изложба Африка",
                ImageUrl = "\\lib\\images\\ExhibitionAfrica.jpg",
                Start = DateTime.Parse("20-07-2023 10:00"),
                End = DateTime.Parse("30-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни."
            };
            await this.exhibitionService.AddAsync(newExhibition);

            var newResult = await this.exhibitionService.GetAllAsync();
            var newCount = newResult.Count();

            Assert.That(newCount, Is.EqualTo(2));
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            int existingexhibitionId = 1;
            bool result = await this.exhibitionService.ExistsByIdAsync(existingexhibitionId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            int existingexhibitionId = 666;
            bool result = await this.exhibitionService.ExistsByIdAsync(existingexhibitionId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetArtEventDetailsAsyncShouldReturnDetailsOfArtEvents()
        {
            var exhibition = await this.exhibitionService.GetExhibitionDetailsAsync(1);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(exhibition);
                Assert.That(exhibition.Id, Is.EqualTo(1));
                Assert.That(exhibition.Name, Is.EqualTo("Изложба Африка"));
                Assert.That(exhibition.ImageUrl, Is.EqualTo("\\lib\\images\\ExhibitionAfrica.jpg"));
                Assert.That(exhibition.Start, Is.EqualTo(DateTime.Parse("20-07-2023 10:00")));
                Assert.That(exhibition.End, Is.EqualTo(DateTime.Parse("30-07-2023 17:00")));
                Assert.That(exhibition.Place, Is.EqualTo("Варна, Галерията на Петя"));
                Assert.That(exhibition.Description, Is.EqualTo("В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни."));
            });
        }

        [Test]
        public async Task DeleteExhibitionAsyncShouldDeleteEntityAndDecreaseAllCount()
        {
            var newResult = await this.exhibitionService.GetAllAsync();
            var newCount = newResult.Count();

            var newExhibition = new ExhibitionFormModel()
            {
                Name = "Изложба Африка",
                ImageUrl = "\\lib\\images\\ExhibitionAfrica.jpg",
                Start = DateTime.Parse("20-07-2023 10:00"),
                End = DateTime.Parse("30-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни."
            };
            await this.exhibitionService.AddAsync(newExhibition);
            await this.exhibitionService.DeleteExhibitionAsync(2);

            Assert.That(newCount, Is.EqualTo(2));
        }
    }
}