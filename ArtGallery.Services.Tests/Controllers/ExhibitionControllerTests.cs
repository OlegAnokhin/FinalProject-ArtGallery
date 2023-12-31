﻿namespace ArtGallery.Services.Tests.Controllers
{
    using System.Security.Claims;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Web.Controllers;
    using Mocks.Models;
    using Data.Interfaces;
    using Moq;

    [TestFixture]
    public class ExhibitionControllerTests
    {
        private Mock<IExhibitionService> exhibitionServiceMock;
        private Mock<ILogger<ExhibitionController>> loggerMock;
        private ExhibitionController controller;

        private const string name = "admin@ArtGallery.bg";
        private const string nameIdentifier = "d53a80c3-5fd9-4451-a381-f40d2f50ec08";
        private const string role = "Administrator";

        [SetUp]
        public async Task SetUp()
        {
            exhibitionServiceMock = new Mock<IExhibitionService>();
            loggerMock = new Mock<ILogger<ExhibitionController>>();
            this.controller = new ExhibitionController(exhibitionServiceMock.Object, loggerMock.Object);

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
            var result = await this.controller.Add(ExhibitionFormModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task AddPostMethodShouldReturnsRedirectToActionWhenModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("test", "test");
            var result = await this.controller.Add(ExhibitionFormModelMock.Instance());

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task DetailsMethodShouldReturnsRedirectToActionWhenExhibitionExist()
        {
            exhibitionServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));
            var result = await this.controller.Details(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task DetailsMethodShouldReturnsRedirectToActionWhenExhibitionNotExist()
        {
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            tempData["ErrorMessage"] = "test";
            controller.TempData = tempData;

            var result = await this.controller.Details(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task DeleteMethodShouldReturnsRedirectToActionWhenExhibitionExist()
        {
            exhibitionServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));
            var result = await this.controller.Delete(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

        [Test]
        public async Task DeleteMethodShouldReturnsRedirectToActionWhenExhibitionNotExist()
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