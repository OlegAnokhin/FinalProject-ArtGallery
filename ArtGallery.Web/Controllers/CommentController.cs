namespace ArtGallery.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services.Data.Interfaces;
    using ViewModels.Comment;
    using ViewModels.Picture;

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

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{

        //    DetailsPictureViewModel model = new DetailsPictureViewModel()
        //    {
        //        Comments = await this.commentService.AllCommentsAsync()
        //    };

        //    return this.View(model);
        //}

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Add(AddAndEditPictureViewModel model)
        //{

        //}

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError("Възникна непредвидена грешка");
                return this.RedirectToAction("All", "Picture");
            }

            try
            {
                await this.commentService.AddAsync(model);
            }
            catch (Exception)
            {
                logger.LogError("Възникна непредвидена грешка");
                return this.RedirectToAction("All", "Picture");
            }

            return this.RedirectToAction("Details", "Picture");

            //var newMessage = comment.CurrentComment;

            //Comments.Add(new KeyValuePair<string, string>
            //    (newMessage.Username, newMessage.Content));

            //return RedirectToAction("Details", "Picture");
        }
    }
}
