namespace ArtGallery.Web.Controllers
{
    using Infrastucture.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using System.Security.Claims;
    using ViewModels.ArtEvent;

    [Authorize]
    public class ArtEventController : Controller
    {
        private readonly IArtEventService artEventService;
        private readonly ILogger logger;
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public ArtEventController(IArtEventService artEventService,
                                  ILogger<ArtEventController> logger)
        {
            this.artEventService = artEventService;
            this.logger = logger;
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
                TempData["ErrorMessage"] = "Възникна непредвидена грешка";
                return RedirectToAction("Error", "Home");
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
            return View(model);
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
                TempData["ErrorMessage"] = "Възникна непредвидена грешка";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool artEventExist = await artEventService.ExistsByIdAsync(id);

            if (!artEventExist)
            {
                TempData["ErrorMessage"] = "Oбучение с такъв идентификатор не съществува.";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                var model = await artEventService.GetArtEventDetailsAsync(id);
                return View(model);
            }
            catch (Exception e)
            {
                logger.LogError("ArtEventController/Details", e);
                TempData["ErrorMessage"] = "Възникна непредвидена грешка";
                return RedirectToAction("Error", "Home");
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
                TempData["ErrorMessage"] = "Oбучение с такъв идентификатор не съществува.";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                await this.artEventService.DeleteArtEventAsync(id);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                logger.LogError("Възникна непредвидена грешка", e);
                TempData["ErrorMessage"] = "Възникна непредвидена грешка";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            if (!User.Identity?.IsAuthenticated ?? false)
            {   
                return RedirectToPage("Login");
            }

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
                TempData["ErrorMessage"] = "Възникна непредвидена грешка";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            try
            {
                var eventToLeave = await artEventService.GetArtEventByIdAsync(id);

                if (eventToLeave == null)
                {
                    TempData["ErrorMessage"] = "Oбучение с такъв идентификатор не съществува.";
                    return RedirectToAction("Error", "Home");
                }

                await artEventService.LeaveFromArtEventAsync(GetUserId(), eventToLeave);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                logger.LogError("Възникна непредвидена грешка", e);
                TempData["ErrorMessage"] = "Възникна непредвидена грешка";
                return RedirectToAction("Error", "Home");
            }
        }
    }
}