namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using Services.Data.Models.Picture;
    using Services.Data.Interfaces;
    using ViewModels.Home;
    using ViewModels.Picture;

    [Authorize]
    public class PictureController : Controller
    {
        private readonly IPictureService pictureService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        private readonly ILogger<PictureController> logger;

        public PictureController(IPictureService pictureService,
                                 ICategoryService categoryService,
                                 ICommentService commentService,
                                 ILogger<PictureController> logger)
        {
            this.pictureService = pictureService;
            this.categoryService = categoryService;
            this.commentService = commentService;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllPictureQueryModel queryModel)
        {
            AllPicturesFilteredAndPagedServiceModel serviceModel = 
                await this.pictureService.AllAsync(queryModel);

            queryModel.Pictures = serviceModel.Pictures;
            queryModel.TotalPictures = serviceModel.TotalPicturesCount;
            queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddAndEditPictureViewModel model = new AddAndEditPictureViewModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddAndEditPictureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }

            bool categoryExist = 
                await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExist)
            {
                logger.LogError("Избрана категория не съществува.");
            }

            try
            {
                await pictureService.AddAsync(model);
            }
            catch (Exception e)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                logger.LogError("GalleryController/Add", e);
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
            }

            return this.RedirectToAction("All", "Picture");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool pictureExist = await this.pictureService
                .ExistByIdAsync(id);

            if (!pictureExist)
            {
                logger.LogError("Картина с този идентификатор не съществува");

                return this.RedirectToAction("All", "Picture");
            }
            DetailsPictureViewModel model = new DetailsPictureViewModel()
            {
                Comments = await this.commentService.AllCommentsAsync()
            };
            model = await this.pictureService
                .GetDetailsByIdAsync(id);

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool pictureExist = await this.pictureService
                .ExistByIdAsync(id);

            if (!pictureExist)
            {
                logger.LogError("Картина с този идентификатор не съществува");

                return this.RedirectToAction("All", "Picture");
            }

            AddAndEditPictureViewModel model = await this.pictureService
                .GetPictureForEditAsync(id);
            model.Categories = await this.categoryService.AllCategoriesAsync();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddAndEditPictureViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }

            bool pictureExist = await this.pictureService
                .ExistByIdAsync(id);

            if (!pictureExist)
            {
                logger.LogError("Картина с този идентификатор не съществува");

                return this.RedirectToAction("All", "Picture");
            }

            try
            {
                await this.pictureService.EditPictureByIdAsync(id, model);
            }
            catch (Exception)
            {
                logger.LogError("Възникна непредвидена грешка");
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }

            return this.RedirectToAction("Details", "Picture", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool pictureExist = await this.pictureService
                .ExistByIdAsync(id);

            if (!pictureExist)
            {
                logger.LogError("Картина с този идентификатор не съществува");

                return this.RedirectToAction("All", "Picture");
            }

            try
            {
                await this.pictureService.DeletePictureByIdAsync(id);
            }
            catch (Exception)
            {
                logger.LogError("Възникна непредвидена грешка");
                return this.RedirectToAction("All", "Picture");
            }
            return this.RedirectToAction("All", "Picture");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
