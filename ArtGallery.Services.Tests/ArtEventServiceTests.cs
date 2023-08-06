using ArtGallery.Data.Models;

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
                Name = "�������� ����� NEW",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
                Place = "�����, ��������� �� ����",
                Description = "�������� ��� ���-����, � ���� ������ �� ���������� ���������� �������, � �� �� �� ������ ����� ������� � �� �� ���������� ���� ������ �����.",
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
              Assert.That(artEvent.Name, Is.EqualTo("�������� �����"));
              Assert.That(artEvent.ImageAddress, Is.EqualTo("\\lib\\images\\ArtEventPinkTree.jpg"));
              Assert.That(artEvent.Start, Is.EqualTo(DateTime.Parse("26-07-2023 17:00")));
              Assert.That(artEvent.Place, Is.EqualTo("�����, ��������� �� ����"));
              Assert.That(artEvent.Description, Is.EqualTo("�������� ��� ���-����, � ���� ������ �� ���������� ���������� �������, � �� �� �� ������ ����� ������� � �� �� ���������� ���� ������ �����."));
          });
        }

        [Test]
        public async Task DeleteArtEventAsyncShouldDecreaseAllArtEventsCount()
        {
            var result = await this.artEventService.GetAllArtEventsAsync();
            var resultCount = result.Count();

            var newEvent = new ArtEventFormModel()
            {
                Name = "�������� ����� NEW",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
                Place = "�����, ��������� �� ����",
                Description = "�������� ��� ���-����, � ���� ������ �� ���������� ���������� �������, � �� �� �� ������ ����� ������� � �� �� ���������� ���� ������ �����.",
            };
            await this.artEventService.AddArtEventAsync(newEvent);
            await this.artEventService.DeleteArtEventAsync(3);

            Assert.That(resultCount - 1, Is.EqualTo(resultCount));
        }
    }
}