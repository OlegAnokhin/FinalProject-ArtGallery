namespace ArtGallery.Web.Areas.Admin.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.User;

    using static Common.GeneralAppConstants;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> All()
        {
            try
            {
                IEnumerable<UserViewModel> model =
                    this.memoryCache.Get<IEnumerable<UserViewModel>>(UsersCasheKey);
                
                if (model == null)
                {
                    model = await this.userService.AllAsync();
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    this.memoryCache.Set(UsersCasheKey, model, cacheOptions);
                }

                return View(model);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}