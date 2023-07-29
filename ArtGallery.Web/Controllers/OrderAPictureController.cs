﻿namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ArtGallery.Services.Data.Interfaces;
    using ViewModels.OrderAPicture;

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

            try
            {
                await orderAPictureService.AddAsync(model);
            }
            catch (Exception e)
            {
                logger.LogError("OrderAPictureController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return RedirectToAction("All", "Picture");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            try
            {
                var model = await orderAPictureService.GetMyOrdersAsync();
                return View(model);
            }
            catch (Exception e)
            {
                logger.LogError("OrderAPictureController/All", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction("All", "Picture");
            }
        }

    }
}