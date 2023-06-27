namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Exhibition;

    public class EventController : Controller
    {
        private readonly IExhibitionService eventService;
        private readonly ILogger logger;

        public EventController(IExhibitionService _eventService, 
                               ILogger<EventController> _logger)
        {
            eventService = _eventService;
            logger = _logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ExhibitionModel> model = Enumerable.Empty<ExhibitionModel>();
            try
            {
                model = await eventService.GetAllAsync();
            }
            catch (Exception e)
            {
                logger.LogError("EventController/Index", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return View("All", model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ExhibitionModel()
            {
                Start = DateTime.Today,
                End = DateTime.Today
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ExhibitionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await eventService.AddAsync(model);
            }
            catch (Exception e)
            {
                logger.LogError("EventController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ExhibitionModel model;
            try
            {
                model = await eventService.GetEventAsync(id);
                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewBag.ErrorMessage = aex.Message;
            }
            catch (Exception e)
            {
                logger.LogError("EventController/Details", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await eventService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                logger.LogError("EventController/Delete", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ExhibitionModel model;
            try
            {
                model = await eventService.GetEventAsync(id);
                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewBag.ErrorMessage = aex.Message;
            }
            catch (Exception e)
            {
                logger.LogError("EventController/Edit", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExhibitionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await eventService.UpdateAsync(model);
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch (ArgumentException aex)
            {
                ViewBag.ErrorMessage = aex.Message;
            }
            catch (Exception e)
            {
                logger.LogError("EventController/Edit", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
