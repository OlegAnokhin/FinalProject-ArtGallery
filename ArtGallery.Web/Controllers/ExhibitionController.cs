﻿namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using Infrastucture.Extensions;
    using ViewModels.Exhibition;

    [Authorize]
    public class ExhibitionController : Controller
    {
        private readonly IExhibitionService exhibitionService;
        private readonly ILogger logger;

        public ExhibitionController(IExhibitionService exhibitionService, 
                               ILogger<ExhibitionController> _logger)
        {
            this.exhibitionService = exhibitionService;
            logger = _logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            try
            {
                var model = await exhibitionService.GetAllAsync();
                return View(model);
            }
            catch (Exception e)
            {
                logger.LogError("ExhibitionController/All", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!User.IsAdmin())
            {
                return RedirectToAction("Error", "Home", StatusCode(401));
            }

            var model = new ExhibitionFormModel()
            {
                Start = DateTime.Today,
                End = DateTime.Today
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(ExhibitionFormModel model)
        {
            if (!User.IsAdmin())
            {
                return RedirectToAction("Error", "Home", StatusCode(401));
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await exhibitionService.AddAsync(model);
                return RedirectToAction("All", "Exhibition");
            }
            catch (Exception e)
            {
                logger.LogError("ExhibitionController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool exhibitionExist = await exhibitionService.ExistsByIdAsync(id);
            
            if (!exhibitionExist)
            {
                ViewBag.ErrorMessage = "Изложба с такъв идентификатор не съществува.";
                return RedirectToAction(nameof(All));
            }

            try
            {
               var model = await exhibitionService.GetExhibitionDetailsAsync(id);
               return View(model);
            }
            catch (Exception e)
            {
                logger.LogError("ExhibitionController/Details", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.IsAdmin())
            {
                return RedirectToAction("Error", "Home", StatusCode(401));
            }
            bool exhibitionExist = await exhibitionService.ExistsByIdAsync(id);

            if (!exhibitionExist)
            {
                ViewBag.ErrorMessage = "Изложба с такъв идентификатор не съществува.";
                return RedirectToAction(nameof(All));
            }

            try
            {
                await this.exhibitionService.DeleteExhibitionAsync(id);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                logger.LogError("Възникна непредвидена грешка");
                return RedirectToAction(nameof(All));
            }
        }
    }
}