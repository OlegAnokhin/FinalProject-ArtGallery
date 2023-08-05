namespace ArtGallery.Web.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ArtGallery.Services.Data.Interfaces;
    using Infrastucture.Extensions;
    using ViewModels.OrderAPicture;
    using static Common.GeneralAppConstants;

    [Authorize]
    public class OrderAPictureController :Controller
    {
        private readonly IOrderAPictureService orderAPictureService;
        private readonly ILogger<OrderAPictureController> logger;
        private readonly IMemoryCache memoryCache;

        public OrderAPictureController(
            IOrderAPictureService orderAPictureService,
            ILogger<OrderAPictureController> logger,
            IMemoryCache memoryCache)
        {
            this.orderAPictureService = orderAPictureService;
            this.logger = logger;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add(OrderAPictureFormModel model)
        {
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Error", "Home", StatusCode(401));
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userId = User.GetId();

            try
            {
                await orderAPictureService.AddAsync(model, userId);
            }
            catch (Exception e)
            {
                logger.LogError("OrderAPictureController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            this.memoryCache.Remove(OrderCasheKey);

            return RedirectToAction("Mine", "OrderAPicture");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.GetId();
            if (userId == null)
            {
                return RedirectToAction("Error", "Home", StatusCode(401));
            }
            try
            {
                var model = await orderAPictureService.GetMyOrdersAsync(userId);
                return View(model);
            }
            catch (Exception e)
            {
                logger.LogError("OrderAPictureController/Mine", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction("All", "Picture");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (Id <= 0)
            {
                ViewBag.ErrorMessage = "Поръчка с такъв идентификатор не съществува.";
                return RedirectToAction("Mine", "OrderAPicture");
            }
            try
            {
                await this.orderAPictureService.DeleteOrderByIdAsync(Id);
            }
            catch (Exception e)
            {
                logger.LogError("OrderAPictureController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            this.memoryCache.Remove(OrderCasheKey);

            if (User.IsAdmin())
            {
                return RedirectToAction("All", "Order", new { area = "Admin" });
            }
            return RedirectToAction("Mine", "OrderAPicture");
        }
    }
}