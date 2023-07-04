namespace ArtGallery.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Home;
    using ViewModels.Picture;

    public class PictureController : Controller
    {
        private readonly IPictureService pictureService;
        private readonly ILogger<PictureController> logger;

        public PictureController(IPictureService pictureService,
                                 ILogger<PictureController> logger)
        {
            this.pictureService = pictureService;
            this.logger = logger;
        }

        public IActionResult Gallery()
        {
            return View("Gallery");
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    var model = new PictureModel();
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PictureModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await pictureService.AddAsync(model);
            }
            catch (Exception e)
            {
                logger.LogError("GalleryController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }

            return RedirectToAction(nameof(Gallery));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            PictureModel model;
            try
            {
                model = await pictureService.GetPictureByIdAsync(id);
                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewBag.ErrorMessage = aex.Message;
            }
            catch (Exception e)
            {
                logger.LogError("GalleryController/Details", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return RedirectToAction(nameof(Gallery));
        }


        [HttpGet]
        public async Task<IActionResult> Animals()
        {
            IEnumerable<PictureModel> model = Enumerable.Empty<PictureModel>();
            try
            {
                model = await pictureService.GetAllAnimalsAsync();
            }
            catch (Exception e)
            {
                logger.LogError("GalleryController/Animals", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }
            return View("Animals", model);
        }

        public IActionResult People()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
