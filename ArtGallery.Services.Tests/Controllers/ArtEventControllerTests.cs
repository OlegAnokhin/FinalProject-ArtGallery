namespace ArtGallery.Services.Tests.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Web.Controllers;
    using Mocks.Models;
    using Data.Interfaces;
    using Moq;
    using ArtGallery.Web.ViewModels.ArtEvent;

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

        [Test]
        public async Task DetailsMethodShouldReturnsRedirectToActionWhenArtEventExist()
        {
            artEventServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            var model = await this.controller.Add(ArtEventFormModelMock.Instance());
            var result = await this.controller.Details(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

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
        public async Task DeleteMethodShouldReturnsRedirectToActionWhenArtEventExist()
        {
            artEventServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Delete(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task DeleteMethodShouldReturnsRedirectToActionWhenArtEventNotExist()
        {
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Delete(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task JoinMethodShouldReturnsRedirectToActionWhenArtEventExist()
        {
            artEventServiceMock.Setup(x => x.GetArtEventByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new AllArtEventViewModel()
                {
                    Id = 1,
                    Name = "Name",
                    ImageAddress = "ImageAddress",
                    Start = DateTime.Today
                }));

            var joinedArtEvents = new List<JoinedArtEventsViewModel>
            {
                new JoinedArtEventsViewModel
                {
                    Id = 1,
                    Name = "Name 1",
                    ImageAddress = "ImageAddress 1",
                    Start = DateTime.Today,
                    Place = "Place 1",
                    Description = "Description 1"
                },
                new JoinedArtEventsViewModel
                {
                    Id = 2,
                    Name = "Name 2",
                    ImageAddress = "ImageAddress 2",
                    Start = DateTime.Today.AddDays(1),
                    Place = "Place 2",
                    Description = "Description 2"
                }
            };

            artEventServiceMock.Setup(x => x.GetJoinedArtEventsAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(joinedArtEvents));

            var result = await this.controller.Join(3);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task LeaveMethodShouldReturnsRedirectToActionWhenArtEventExist()
        {
            artEventServiceMock.Setup(x => x.GetArtEventByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new AllArtEventViewModel()
                {
                    Id = 1,
                    Name = "Name",
                    ImageAddress = "ImageAddress",
                    Start = DateTime.Today
                }));

            var result = await this.controller.Leave(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task LeaveMethodShouldReturnsRedirectToActionWhenArtEventNotExist()
        {
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Leave(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }
    }
}