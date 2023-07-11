namespace ArtGallery.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Home;
    using Services.Data.Interfaces;

    public class HomeController : Controller
    {
        private readonly IPictureService pictureService;
        public HomeController(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = 
                await this.pictureService.LastThreePicturesAsync();

            return View(viewModel);
        }

        public IActionResult About()
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