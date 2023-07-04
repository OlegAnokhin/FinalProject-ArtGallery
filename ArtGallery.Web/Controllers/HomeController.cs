using ArtGallery.Services.Data.Interfaces;

namespace ArtGallery.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Home;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}