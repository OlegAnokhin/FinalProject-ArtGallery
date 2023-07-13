using ArtGallery.Web.ViewModels.ArtEvent;

namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ArtGallery.Services.Data.Interfaces;

    [Authorize]
    public class ArtEventController : Controller
    {
        private readonly IArtEventService artEventService;
        private readonly ILogger logger;

        public ArtEventController(IArtEventService artEventService,
                                  ILogger<ArtEventController> _logger)
        {
            this.artEventService = artEventService;
            logger = _logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var model = await artEventService.GetAllArtEventsAsync();
                return View(model);
            }
            catch (Exception e)
            {
                logger.LogError("ArtEventController/All", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(ArtEventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await artEventService.AddArtEventAsync(model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                logger.LogError("ArtEventController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction(nameof(All));
            }
        }
    }
}