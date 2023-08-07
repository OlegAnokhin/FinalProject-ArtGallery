namespace ArtGallery.Services.Tests
{

    using Microsoft.EntityFrameworkCore;
    using Data;
    using ArtGallery.Data;
    using Data.Interfaces;
    using Web.ViewModels.User;
    using static DatabaseSeeder;

    public class UserServiceTests
    {
        private DbContextOptions<ArtGalleryDbContext> dbOptions;
        private ArtGalleryDbContext dbContext;
        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ArtGalleryDbContext>()
                .UseInMemoryDatabase("ArtGalleryInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ArtGalleryDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.userService = new UserService(this.dbContext);
        }

        [Test]
        public async Task AllAsyncShouldTakeAllUsers()
        {
            var result = await this.userService.AllAsync();
            var resultCount = result.Count();

            Assert.That(resultCount, Is.EqualTo(2));
        }

        [Test]
        public async Task AllAsyncShouldTakeAllUsersAndEveryUserContainsValues()
        {
            var actualUsers = await this.userService.AllAsync();
            var users = actualUsers.ToArray();

            var currentUser = users[0];
            Assert.That(currentUser.Id, Is.EqualTo("d53a80c3-5fd9-4451-a381-f40d2f50ec08"));
            Assert.That(currentUser.Email, Is.EqualTo("admin@ArtGallery.bg"));
        }
    }
}
