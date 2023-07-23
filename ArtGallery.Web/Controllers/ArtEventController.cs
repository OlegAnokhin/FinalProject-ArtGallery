namespace ArtGallery.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;
    using ViewModels.ArtEvent;
    using Services.Data.Interfaces;
    using Infrastucture.Extensions;

    [Authorize]
    public class ArtEventController : Controller
    {
        private readonly IArtEventService artEventService;
        private readonly ILogger logger;
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

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
            if (!User.IsAdmin())
            {
                return RedirectToAction("Error", "Home", StatusCode(401));
            }
            var model = new ArtEventFormModel()
            {
                Start = DateTime.Today
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ArtEventFormModel model)
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool artEventExist = await artEventService.ExistsByIdAsync(id);

            if (!artEventExist)
            {
                ViewBag.ErrorMessage = "Oбучение с такъв идентификатор не съществува.";
                return RedirectToAction(nameof(All));
            }

            try
            {
                var model = await artEventService.GetArtEventDetailsAsync(id);
                return View(model);
            }
            catch (Exception e)
            {
                logger.LogError("ArtEventController/Details", e);
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
            bool artEventExist = await artEventService.ExistsByIdAsync(id);

            if (!artEventExist)
            {
                ViewBag.ErrorMessage = "Oбучение с такъв идентификатор не съществува.";
                return RedirectToAction(nameof(All));
            }

            try
            {
                await this.artEventService.DeleteArtEventAsync(id);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                logger.LogError("Възникна непредвидена грешка", e);
                return RedirectToAction(nameof(Details));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var artEventToJoin = await artEventService.GetArtEventByIdAsync(id);
            var model = await artEventService.GetJoinedArtEventsAsync(GetUserId());

            if (model.Any(m => m.Id == id))
            {
                return RedirectToAction(nameof(All));
            }

            try
            {
                await artEventService.JoinToArtEventAsync(GetUserId(), artEventToJoin);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                logger.LogError("Възникна непредвидена грешка", e);
                return RedirectToAction(nameof(Details));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var eventToLeave = await artEventService.GetArtEventByIdAsync(id);
            await artEventService.LeaveFromArtEventAsync(GetUserId(), eventToLeave);

            return RedirectToAction(nameof(All));
        }
    }
}