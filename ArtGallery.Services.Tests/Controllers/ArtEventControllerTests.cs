using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Services.Tests.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Web.Controllers;
    using Mocks;
    using Mocks.Models;
    using Mocks.Services;
    using ArtGallery.Services.Data.Interfaces;
    using Moq;

    [TestFixture]
    public class ArtEventControllerTests
    {
        private Mock<IArtEventService> artEventServiceMock;
        private Mock<ILogger<ArtEventController>> loggerMock;
        private ArtEventController controller;

        private const string name = "admin@ArtGallery.bg";
        private const string nameIdentifier = "d53a80c3-5fd9-4451-a381-f40d2f50ec08";
        private const string role = "Administrator";

        [SetUp]
        public async Task SetUp()
        {
            artEventServiceMock = new Mock<IArtEventService>();
            loggerMock = new Mock<ILogger<ArtEventController>>();
            this.controller = new ArtEventController(artEventServiceMock.Object, loggerMock.Object);

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
        public async Task AllMethodShouldReturnsViewWhenModelStateIsValid()
        {
            var controller = this.controller;

            IActionResult result = await controller.All();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void AddGetMethodShouldReturnsView()
        {
            var result = this.controller.Add();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task AddPostMethodShouldReturnsRedirectToActionWhenModelStateIsValid()
        {
            var result = await this.controller.Add(ArtEventFormModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task AddPostMethodShouldReturnsRedirectToActionWhenModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("test", "test");
            var result = await this.controller.Add(ArtEventFormModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        //[Test]
        //public async Task DetailsMethodShouldReturnsRedirectToActionWhenArtEventExist()
        //{
        //    var model = await this.controller.Add(ArtEventFormModelMock.Instance());
        //    var result = await this.controller.Details(1);

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf<ViewResult>());
        //}

        [Test]
        public async Task DetailsMethodShouldReturnsRedirectToActionWhenArtEventNotExist()
        {
            artEventServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(false));
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Details(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task DeleteMethodShouldReturnsRedirectToActionWhenArtEventNotExist()
        {
            var result = await this.controller.Delete(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        //[Test]
        //public async Task JoinMethodShouldReturnsRedirectToActionWhenArtEventNotExist()
        //{
        //    var result = await this.controller.Join(1);

        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        //}

        [Test]
        public async Task LeaveMethodShouldReturnsRedirectToActionWhenArtEventNotExist()
        {
            var result = await this.controller.Leave(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }
    }
}