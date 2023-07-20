namespace ArtGallery.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services.Data.Interfaces;
    using ViewModels.Comment;
    using ViewModels.Picture;
    using System.Security.Claims;

    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IPictureService pictureService;
        private readonly ILogger<CommentController> logger;

        public CommentController(ICommentService commentService,
                                 IPictureService pictureService,
                                 ILogger<CommentController> logger)
        {
            this.commentService = commentService;
            this.pictureService = pictureService;
            this.logger = logger;
        }

        //private static List<KeyValuePair<string, string>> Comments = new List<KeyValuePair<string, string>>();

        //public IActionResult Show()
        //{
        //    if (Comments.Count() < 1)
        //    {
        //        return View(new CommentFormModel());
        //    }

        //    var chatModel = new CommentFormModel()
        //    {
        //        Comments = Comments
        //            .Select(m => new CommentViewModel()
        //            {
        //                Username = m.Key,
        //                Content = m.Value
        //            })
        //            .ToList()
        //    };

        //    return View(chatModel);
        //}

        [HttpGet]
        public IActionResult Add()
        {
           // var model = new CommentViewModel { PictureId = pictureId };
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int pictureId, CommentViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    logger.LogError("Възникна непредвидена грешка");
            //    return this.RedirectToAction("All", "Picture");
            //}

            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!user.Any())
            {
                logger.LogError("Потребител не съществува");

                return this.RedirectToAction("All", "Picture");
            }
            var userId = user;

            //if (Request.Cookies.TryGetValue("Id", out string idValue))
            //{
            //    int.TryParse(idValue, out picId);
            //}

            bool pictureExist = await this.pictureService
                .ExistByIdAsync(pictureId);

            if (!pictureExist)
            {
                logger.LogError("Картина с този идентификатор не съществува");

                return this.RedirectToAction("All", "Picture");
            }

            try
            {
                await this.commentService.AddCommentAsync(pictureId, model);
            }
            catch (Exception)
            {
                logger.LogError("Възникна непредвидена грешка");
                return this.RedirectToAction("All", "Picture");
            }

            return this.RedirectToAction("Details", "Picture", new{pictureId});

            //var newMessage = comment.CurrentComment;

            //Comments.Add(new KeyValuePair<string, string>
            //    (newMessage.Username, newMessage.Content));

            //return RedirectToAction("Details", "Picture");
        }
    }
}
