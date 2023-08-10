namespace ArtGallery.Services.Tests.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Web.Controllers;
    using Tests.Mocks.Services;

    [TestFixture]
    public class ExhibitionControllerTests
    {
        private ExhibitionController controller;

        private const string name = "admin@ArtGallery.bg";
        private const string nameIdentifier = "d53a80c3-5fd9-4451-a381-f40d2f50ec08";
        private const string role = "Administrator";

        [SetUp]
        public async Task SetUp()
        {
            this.controller = new ExhibitionController(await ExhibitionServiceMock.Instance());

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


    }
}