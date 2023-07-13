namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ArtGallery.Services.Data.Interfaces;

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
                return RedirectToAction(nameof(All));
            }
        }
    }
}