namespace ArtGallery.Services.Tests.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Moq;
    using Data.Models.Picture;
    using Data.Interfaces;
    using Mocks.Models;
    using Web.Controllers;
    using Web.ViewModels.Picture;

    [TestFixture]
    public class PictureControllerTests
    {
        private Mock<IPictureService> pictureServiceMock;
        private Mock<ICategoryService> categoryServiceMock;
        private Mock<ICommentService> commentServiceMock;
        private Mock<ILogger<PictureController>> loggerMock;
        private PictureController controller;

        private const string name = "admin@ArtGallery.bg";
        private const string nameIdentifier = "d53a80c3-5fd9-4451-a381-f40d2f50ec08";
        private const string role = "Administrator";

        [SetUp]
        public async Task SetUp()
        {
            pictureServiceMock = new Mock<IPictureService>();
            categoryServiceMock = new Mock<ICategoryService>();
            commentServiceMock = new Mock<ICommentService>();
            loggerMock = new Mock<ILogger<PictureController>>();
            this.controller = new PictureController(pictureServiceMock.Object, categoryServiceMock.Object, commentServiceMock.Object, loggerMock.Object);

            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim(ClaimTypes.Role, role)
            }, "mock"));

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };
        }

        [Test]
        public async Task AllMethodReturnsCorrectViewAndModel()
        {
            var pictureList = new List<AllPictureViewModel>
            {
                new AllPictureViewModel { Id = 1, Name = "Picture 1", ImageAddress = "url1.jpg" },
                new AllPictureViewModel() { Id = 2, Name = "Picture 2", ImageAddress = "url2.jpg" }
            };
            var queryModel = new AllPictureQueryModel();
            var serviceModel = new AllPicturesFilteredAndPagedServiceModel
            {
                Pictures = pictureList,
                TotalPicturesCount = 10
            };

            pictureServiceMock.Setup(x => x.AllAsync(queryModel))
                .ReturnsAsync(serviceModel);

            categoryServiceMock.Setup(x => x.AllCategoryNamesAsync())
                .ReturnsAsync(new List<string>());

            var result = await controller.All(queryModel) as ViewResult;

            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.IsInstanceOf<AllPictureQueryModel>(result.Model);
        }

        [Test]
        public async Task AddGetMethodShouldRedirectToActionWhenUserNotAdmin()
        {
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "name"),
                new Claim(ClaimTypes.NameIdentifier, "nameIdentifier"),
                new Claim(ClaimTypes.Role, "role")
            }, "mock"));

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user
                }
            };

            var result = await this.controller.Add();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task AddGetMethodShouldReturnsView()
        {
            var result = await this.controller.Add();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task AddPostMethodShouldReturnsRedirectToActionWhenModelStateIsValid()
        {
            categoryServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));
            var result = await this.controller.Add(AddAndEditPictureViewModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task AddPostMethodShouldReturnsViewResultModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("test", "test");
            var result = await this.controller.Add(AddAndEditPictureViewModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task DetailsMethodShouldReturnsViewResultWhenPictureExist()
        {
            pictureServiceMock.Setup(x => x.ExistByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            pictureServiceMock.Setup(x => x.GetDetailsByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new DetailsPictureViewModel
                {
                    Id = 1,
                    Name = "Name",
                    Size = "Size",
                    Material = "Material",
                    ImageAddress = "ImageAddress",
                    ImageBase = "ImageBase",
                    Description = "Description"
                }));
            var result = await this.controller.Details(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task DetailsMethodShouldReturnsRedirectToActionWhenPictureNotExist()
        {
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Details(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task EditGetMethodShouldReturnsViewResultWhenPictureExist()
        {
            pictureServiceMock.Setup(x => x.ExistByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            pictureServiceMock.Setup(x => x.GetPictureForEditAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new AddAndEditPictureViewModel()
                {
                    Name = "Name",
                    Size = "Size",
                    Material = "Material",
                    ImageAddress = "ImageAddress",
                    ImageBase = "ImageBase",
                    CategoryId = 1,
                    Description = "Description"
                }));
            var result = await this.controller.Edit(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task EditGetMethodShouldReturnsRedirectToActionWhenPictureNotExist()
        {
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Edit(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task EditPostMethodShouldReturnsRedirectToActionWhenPictureExist()
        {
            pictureServiceMock.Setup(x => x.ExistByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            var result = await this.controller.Edit(1, AddAndEditPictureViewModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task EditPostMethodShouldReturnsViewResultWhenModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("test", "test");
            var result = await this.controller.Edit(1, AddAndEditPictureViewModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task EditPostMethodShouldReturnsRedirectToActionWhenArtEventNotExist()
        {
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Edit(1, AddAndEditPictureViewModelMock.Instance());


            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task DeleteMethodShouldReturnsRedirectToActionWhenPictureExist()
        {
            pictureServiceMock.Setup(x => x.ExistByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            var result = await this.controller.Delete(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task DeleteMethodShouldReturnsRedirectToActionWhenPictureNotExist()
        {
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Delete(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }
    }
}