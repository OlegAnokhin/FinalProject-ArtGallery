namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
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
        [AllowAnonymous]
        [HttpGet]
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await exhibitionService.AddAsync(model);
            }
            catch (Exception e)
            {
                logger.LogError("EventController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }

            return RedirectToAction(nameof(All));
        }

        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    AddExhibitionViewModel model;
        //    try
        //    {
        //        model = await eventService.GetEventAsync(id);
        //        return View(model);
        //    }
        //    catch (ArgumentException aex)
        //    {
        //        ViewBag.ErrorMessage = aex.Message;
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError("EventController/Details", e);
        //        ViewBag.ErrorMessage = "Възникна непредвидена грешка";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await eventService.DeleteAsync(id);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError("EventController/Delete", e);
        //        ViewBag.ErrorMessage = "Възникна непредвидена грешка";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    AddExhibitionViewModel model;
        //    try
        //    {
        //        model = await eventService.GetEventAsync(id);
        //        return View(model);
        //    }
        //    catch (ArgumentException aex)
        //    {
        //        ViewBag.ErrorMessage = aex.Message;
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError("EventController/Edit", e);
        //        ViewBag.ErrorMessage = "Възникна непредвидена грешка";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(AddExhibitionViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    try
        //    {
        //        await eventService.UpdateAsync(model);
        //        return RedirectToAction(nameof(Details), new { id = model.Id });
        //    }
        //    catch (ArgumentException aex)
        //    {
        //        ViewBag.ErrorMessage = aex.Message;
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError("EventController/Edit", e);
        //        ViewBag.ErrorMessage = "Възникна непредвидена грешка";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
