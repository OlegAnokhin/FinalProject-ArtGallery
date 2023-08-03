namespace ArtGallery.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Services.Data.Interfaces;
    using ViewModels.OrderAPicture;
    using static Common.GeneralAppConstants;

    public class OrderController : BaseAdminController
    {
        private readonly IOrderAPictureService orderService;
        private readonly IMemoryCache memoryCache;

        public OrderController(IOrderAPictureService orderService, IMemoryCache memoryCache)
        {
            this.orderService = orderService;
            this.memoryCache = memoryCache;
        }

        [ResponseCache(Duration = 120)]
        public async Task<IActionResult> All()
        {
            try
            {
                var model = this.memoryCache.Get<IEnumerable<MyOrdersViewModel>>(OrderCasheKey);

                if (model == null)
                {
                    model = await this.orderService.AllAsync();
                    var casheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                    this.memoryCache.Set(OrderCasheKey, model, casheOptions);
                }
                return View(model);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}