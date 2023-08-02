namespace ArtGallery.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;

    public class OrderController : BaseAdminController
    {
        private readonly IOrderAPictureService orderService;

        public OrderController(IOrderAPictureService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> All()
        {
            try
            {
                var model = await orderService.AllAsync();
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}