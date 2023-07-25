namespace ArtGallery.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Home;
    using Services.Data.Interfaces;

    public class HomeController : Controller
    {
        private readonly IPictureService pictureService;
        private readonly IConfiguration _configuration;

        public HomeController(IPictureService pictureService, IConfiguration configuration)
        {
            this.pictureService = pictureService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            int.TryParse(_configuration["Settings:PictureCount"], out int pictureCount);
            IEnumerable<IndexViewModel> viewModel = 
                await this.pictureService.LastPicturesAsync(pictureCount);

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}