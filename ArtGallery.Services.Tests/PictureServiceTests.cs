namespace ArtGallery.Services.Tests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using ArtGallery.Data;
    using Data.Interfaces;
    using Web.ViewModels.Picture;
    using Web.ViewModels.Picture.Enums;
    using static DatabaseSeeder;

    [TestFixture]
    public class PictureServiceTests
    {
        private DbContextOptions<ArtGalleryDbContext> dbOptions;
        private ArtGalleryDbContext dbContext;
        private IPictureService pictureService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ArtGalleryDbContext>()
                .UseInMemoryDatabase("ArtGalleryInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ArtGalleryDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.pictureService = new PictureService(this.dbContext);
        }

        [Test]
        public async Task LastPicturesAsyncShouldReturnSameCountOfPictures()
        {
            var result = await this.pictureService.LastPicturesAsync(3);
            var resultCount = result.Count();

            Assert.That(resultCount, Is.EqualTo(3));
        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategories()
        {
            var result = await this.pictureService.GetCategoriesForAddNewPictureAsync();
            var resultCount = result.Categories.Count();

            Assert.That(resultCount, Is.EqualTo(4));
        }

        [Test]
        public async Task AddArtEventAsyncShouldReturnCountForAllArtEvents()
        {
            var newPicture = new AddAndEditPictureViewModel()
            {
                Name = "Момиче с голямо цвете",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Girl1.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче с цвете в косата",
            };
            await this.pictureService.AddAsync(newPicture);

            var queryModel = new AllPictureQueryModel
            {
                PictureSorting = PictureSorting.Newest,
                CurrentPage = 1,
                PicturesPerPage = 50,
            };
            var newResult = await this.pictureService.AllAsync(queryModel);
            var newCount = newResult.Pictures.Count();

            Assert.That(newCount, Is.EqualTo(13));
        }

        [Test]
        public async Task EditPictureByIdAsyncShouldGetPictureByIdAndShowSameValues()
        {
            var newPicture = new AddAndEditPictureViewModel()
            {
                Name = "Момиче с голямо цвете",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Girl1.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче с цвете в косата",
            };
            await this.pictureService.AddAsync(newPicture);
            var picture = this.pictureService.EditPictureByIdAsync(12, newPicture);

            Assert.Multiple(() =>
            {
                Assert.That(newPicture.Name, Is.EqualTo("Момиче с голямо цвете"));
                Assert.That(newPicture.Size, Is.EqualTo("40 х 60"));
                Assert.That(newPicture.Material, Is.EqualTo("Акрил"));
                Assert.That(newPicture.ImageAddress, Is.EqualTo("\\lib\\images\\Girl1.jpg"));
                Assert.That(newPicture.ImageBase, Is.EqualTo("Платно"));
                Assert.That(newPicture.CategoryId, Is.EqualTo(2));
                Assert.That(newPicture.Description, Is.EqualTo("Африканско момиче с цвете в косата"));
            });
        }

        [Test]
        public async Task GetDetailsByIdAsyncShouldGetPictureByIdAndShowSameValues()
        {
            var picture = await this.pictureService.GetDetailsByIdAsync(1);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(picture);
                Assert.That(picture.Id, Is.EqualTo(1));
                Assert.That(picture.Name, Is.EqualTo("Момиче с цвете"));
                Assert.That(picture.Size, Is.EqualTo("40 х 60"));
                Assert.That(picture.Material, Is.EqualTo("Акрил"));
                Assert.That(picture.ImageAddress, Is.EqualTo("\\lib\\images\\Girl1.jpg"));
                Assert.That(picture.ImageBase, Is.EqualTo("Платно"));
                Assert.That(picture.Category, Is.EqualTo("Хора"));
                Assert.That(picture.Description, Is.EqualTo("Африканско момиче с цвете в косата"));
            });
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnTrueWhenExists()
        {
            int existingPictureId = 1;
            bool result = await this.pictureService.ExistByIdAsync(existingPictureId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnFalseWhenNotExists()
        {
            int existingPictureId = 666;
            bool result = await this.pictureService.ExistByIdAsync(existingPictureId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetPictureForEditAsyncShouldGetPictureByIdAndShowSameValues()
        {
            var picture = await this.pictureService.GetPictureForEditAsync(1);
            var createdData = picture.CreatedOn;

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(picture);
                Assert.That(picture.Name, Is.EqualTo("Момиче с цвете"));
                Assert.That(picture.Size, Is.EqualTo("40 х 60"));
                Assert.That(picture.Material, Is.EqualTo("Акрил"));
                Assert.That(picture.ImageAddress, Is.EqualTo("\\lib\\images\\Girl1.jpg"));
                Assert.That(picture.ImageBase, Is.EqualTo("Платно"));
                Assert.That(picture.CategoryId, Is.EqualTo(2));
                Assert.That(picture.Description, Is.EqualTo("Африканско момиче с цвете в косата"));
                Assert.That(picture.CreatedOn, Is.EqualTo(createdData));
            });
        }

        [Test]
        public async Task DeletePictureByIdAsyncShouldRetutnFalseIfNotExists()
        {
            var newPicture = new AddAndEditPictureViewModel()
            {
                Name = "Момиче с голямо цвете",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Girl1.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче с цвете в косата",
            };
            await this.pictureService.AddAsync(newPicture);
            await this.pictureService.DeletePictureByIdAsync(13);

            var result = await this.pictureService.ExistByIdAsync(13);
            
            Assert.IsFalse(result);
        }
    }
}