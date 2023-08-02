namespace ArtGallery.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using Infrastucture.Extensions;

    public class CommentController : BaseAdminController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public async Task<IActionResult> All()
        {
            try
            {
                var model = await commentService.AllCommentsWithAdminAsync();
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Възникна непредвидена грешка";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int commentId)
        {
            if (!User.IsAdmin())
            {
                return this.RedirectToAction("Error", "Home", StatusCode(401));
            }
            bool commentExist = await commentService.ExistsByIdAsync(commentId);

            if (!commentExist)
            {
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                await this.commentService.DeleteCommentAsync(commentId);
                return this.RedirectToAction("All", "Comment");
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }
        }
    }
}