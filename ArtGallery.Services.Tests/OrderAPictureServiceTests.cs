namespace ArtGallery.Services.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using ArtGallery.Data;
    using Data.Interfaces;
    using Web.ViewModels.OrderAPicture;
    using static DatabaseSeeder;

    public class OrderAPictureServiceTests
    {
        private DbContextOptions<ArtGalleryDbContext> dbOptions;
        private ArtGalleryDbContext dbContext;
        private IOrderAPictureService orderAPictureService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ArtGalleryDbContext>()
                .UseInMemoryDatabase("ArtGalleryInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ArtGalleryDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.orderAPictureService = new OrderAPictureService(this.dbContext);
        }

        [Test]
        public async Task GetAllOrdersAsyncShouldTakeAllOrders()
        {
            var result = await this.orderAPictureService.AllAsync();
            var resultCount = result.Count();

            Assert.That(resultCount, Is.EqualTo(1));
        }

        [Test]
        public async Task AddAsyncShouldAddNewOrderAndIncreaseCountForAllOrders()
        {
            var userId = "c1f40236-ee63-452f-8c56-18f952098074";

            var newOrder = new OrderAPictureFormModel
            {
                FullName = "test",
                PhoneNumber = "787878787878",
                Size = "40 x 60",
                Material = "test",
                ImageBase = "test",
                Description = "test"
            };
            await this.orderAPictureService.AddAsync(newOrder, userId);

            var newResult = await this.orderAPictureService.AllAsync();
            var newCount = newResult.Count();

            Assert.That(newCount, Is.EqualTo(1));
        }

        [Test]
        public async Task GetMyOrdersAsyncShouldReturnCountForCurrentUserOrders()
        {
            var userId = "c1f40236-ee63-452f-8c56-18f952098074";
            var newOrder = new OrderAPictureFormModel
            {
                FullName = "test",
                PhoneNumber = "787878787878",
                Size = "40 x 60",
                Material = "test",
                ImageBase = "test",
                Description = "test"
            };
            await this.orderAPictureService.AddAsync(newOrder, userId);

            var result = await this.orderAPictureService.GetMyOrdersAsync(userId);
            var count = result.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteOrderByIdAsyncShouldDecreaseMyOrdersCount()
        {
            var userId = "c1f40236-ee63-452f-8c56-18f952098074";
            var result = await this.orderAPictureService.GetMyOrdersAsync(userId);
            var count = result.Count();

            var newOrder = new OrderAPictureFormModel
            {
                FullName = "test",
                PhoneNumber = "787878787878",
                Size = "40 x 60",
                Material = "test",
                ImageBase = "test",
                Description = "test"
            };
            await this.orderAPictureService.AddAsync(newOrder, userId);
            await this.orderAPictureService.DeleteOrderByIdAsync(2);

            Assert.That(count, Is.EqualTo(1));
        }
    }
}