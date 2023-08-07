namespace ArtGallery.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Interfaces;
    using ArtGallery.Data;
    using Web.ViewModels.ArtEvent;
    using static DatabaseSeeder;

    public class ArtEventServiceTests
    {
        private DbContextOptions<ArtGalleryDbContext> dbOptions;
        private ArtGalleryDbContext dbContext;
        private IArtEventService artEventService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ArtGalleryDbContext>()
                .UseInMemoryDatabase("ArtGalleryInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ArtGalleryDbContext(this.dbOptions);
            
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.artEventService = new ArtEventService(this.dbContext);
        }

        [Test]
        public async Task GetAllArtEventsAsyncShouldTakeAllArtEvents()
        {
            var result = await this.artEventService.GetAllArtEventsAsync();
            var resultCount = result.Count();
            
            Assert.That(resultCount, Is.EqualTo(5));
        }

        [Test]
        public async Task AddArtEventAsyncShouldReturnCountForAllArtEvents()
        {
            var newEvent = new ArtEventFormModel()
            {
                Name = "Розовото дърво NEW",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
            };
            await this.artEventService.AddArtEventAsync(newEvent);

            var newResult = await this.artEventService.GetAllArtEventsAsync();
            var newCount = newResult.Count();

            Assert.That(newCount, Is.EqualTo(5));
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            int existingArtEventId = artEvent.Id;
            bool result = await this.artEventService.ExistsByIdAsync(existingArtEventId);

            Assert.IsTrue(result);
        }
        
        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            int existingArtEventId = 666;
            bool result = await this.artEventService.ExistsByIdAsync(existingArtEventId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetArtEventDetailsAsyncShouldReturnDetailsOfArtEvents()
        {
            var artEvent = await this.artEventService.GetArtEventDetailsAsync(1);

          Assert.Multiple(() =>
          {
              Assert.IsNotNull(artEvent);
              Assert.That(artEvent.Id, Is.EqualTo(1));
              Assert.That(artEvent.Name, Is.EqualTo("Розовото дърво"));
              Assert.That(artEvent.ImageAddress, Is.EqualTo("\\lib\\images\\ArtEventPinkTree.jpg"));
              Assert.That(artEvent.Start, Is.EqualTo(DateTime.Parse("26-07-2023 17:00")));
              Assert.That(artEvent.Place, Is.EqualTo("Варна, Галерията на Петя"));
              Assert.That(artEvent.Description, Is.EqualTo("Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време."));
          });
        }

        [Test]
        public async Task DeleteArtEventAsyncShouldDecreaseAllArtEventsCount()
        {
            var result = await this.artEventService.GetAllArtEventsAsync();
            var resultCount = result.Count();

            var newEvent = new ArtEventFormModel()
            {
                Name = "Розовото дърво NEW",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
            };
            await this.artEventService.AddArtEventAsync(newEvent);
            await this.artEventService.DeleteArtEventAsync(2);

            Assert.That(resultCount, Is.EqualTo(5));
        }

        [Test]
        public async Task GetArtEventByIdAsyncShouldReturnTrueWhenExists()
        {
            var newEvent = new AllArtEventViewModel
            {
                Id = 1,
                Name = "Розовото дърво",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
            };

            var result = await this.artEventService.GetArtEventByIdAsync(1);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(newEvent.Id));
                Assert.That(result.Name, Is.EqualTo(newEvent.Name));
                Assert.That(result.ImageAddress, Is.EqualTo(newEvent.ImageAddress));
                Assert.That(result.Start, Is.EqualTo(newEvent.Start));

            });
        }

        [Test]
        public async Task JoinToArtEventsAsyncShouldReturnAllJoinedEvent()
        {
            var userId = "c1f40236-ee63-452f-8c56-18f952098074";

            var newEvent = new AllArtEventViewModel
            {
                Id = 1,
                Name = "Розовото дърво NEW",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
            };

            await this.artEventService.JoinToArtEventAsync(userId, newEvent);

            var result = await this.artEventService.GetJoinedArtEventsAsync(userId);
            var resultCount = result.Count();

            Assert.That(resultCount, Is.EqualTo(1));
        }

        [Test]
        public async Task LeaveFromArtEventAsyncShouldDecreaseParticipantsCountForArtEvent()
        {
            var userId = "c1f40236-ee63-452f-8c56-18f952098074";

            var newEvent = new AllArtEventViewModel
            {
                Id = 1,
                Name = "Розовото дърво NEW",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
            };

            await this.artEventService.LeaveFromArtEventAsync(userId, newEvent);

            var result = await this.artEventService.GetJoinedArtEventsAsync(userId);
            var resultCount = result.Count();

            Assert.That(resultCount, Is.EqualTo(0));
        }

        [Test]
        public async Task GetCountOfParticipantAsyncShouldReturnCountOfParticipant()
        {
            var userId = "c1f40236-ee63-452f-8c56-18f952098074";

            var newEvent = new AllArtEventViewModel
            {
                Id = 1,
                Name = "Розовото дърво NEW",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
            };

            await this.artEventService.JoinToArtEventAsync(userId, newEvent);

            var result = await this.artEventService.GetCountOfParticipantAsync(1);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}