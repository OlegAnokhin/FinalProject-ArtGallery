namespace ArtGallery.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Home;
    using ViewModels.Picture;

    [Authorize]
    public class PictureController : Controller
    {
        private readonly IPictureService pictureService;
        private readonly ICategoryService categoryService;
        private readonly ILogger<PictureController> logger;

        public PictureController(IPictureService pictureService,
                                 ICategoryService categoryService,
                                 ILogger<PictureController> logger)
        {
            this.pictureService = pictureService;
            this.categoryService = categoryService;
            this.logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddPictureViewModel model = new AddPictureViewModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddPictureViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            //try
            //{
            //    await pictureService.AddAsync(model);
            //}
            //catch (Exception e)
            //{
            //    logger.LogError("GalleryController/Add", e);
            //    ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            //}

            return RedirectToAction(nameof(All));
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
            return RedirectToAction(nameof(All));
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
