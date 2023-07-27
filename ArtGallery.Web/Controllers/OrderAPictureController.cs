namespace ArtGallery.Web.Controllers
{
    using ArtGallery.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class OrderAPictureController :Controller
    {
        private readonly IOrderAPictureService orderAPictureService;
        private readonly ILogger<OrderAPictureController> logger;

        public OrderAPictureController(
            IOrderAPictureService orderAPictureService,
            ILogger<OrderAPictureController> logger)
        {
            this.orderAPictureService = orderAPictureService;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Add()
        {
            return this.View();
        }

    }
}