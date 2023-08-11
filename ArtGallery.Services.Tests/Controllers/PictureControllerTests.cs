namespace ArtGallery.Services.Tests.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Data.Interfaces;
    using Web.Controllers;
    using Mocks.Models;

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

        //[Test]
        //public void AddGetMethodShouldReturnsView()
        //{
        //    var categories = new List<PictureSelectCategoryModel>
        //    {
        //        new PictureSelectCategoryModel
        //        {
        //            Id = 1,
        //            Name = "Name"
        //        }
        //    };
        //    //categoryServiceMock.Setup(x => x.AllCategoriesAsync())
        //    //    .Returns(Task.FromResult(new AddAndEditPictureViewModel()
        //    //    {
        //    //        Name = "Name",
        //    //        Size = "Size",
        //    //        Material = "Material",
        //    //        ImageAddress = "ImageAddress",
        //    //        ImageBase = "ImageBase",
        //    //        CategoryId = 1,
        //    //        Description = "Description",
        //    //        CreatedOn = DateTime.UtcNow
        //    //    }));
        //    var result = this.controller.Add();

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf<ViewResult>());
        //}

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
        public async Task AddPostMethodShouldReturnsRedirectToActionWhenModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("test", "test");
            var result = await this.controller.Add(AddAndEditPictureViewModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

    }
}