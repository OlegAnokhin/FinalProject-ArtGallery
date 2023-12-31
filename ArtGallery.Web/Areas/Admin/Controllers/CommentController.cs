﻿namespace ArtGallery.Web.Areas.Admin.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using Infrastucture.Extensions;
    using ViewModels.Comment;
    using static Common.GeneralAppConstants;

    public class CommentController : BaseAdminController
    {
        private readonly ICommentService commentService;
        private readonly IMemoryCache memoryCache;

        public CommentController(ICommentService commentService, IMemoryCache memoryCache)
        {
            this.commentService = commentService;
            this.memoryCache = memoryCache;
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> All()
        {
            try
            {
                var model = this.memoryCache.Get<IEnumerable<CommentViewModel>>(CommentCasheKey);

                if (model == null)
                {
                    model = await commentService.AllCommentsWithAdminAsync();
                    var casheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                    this.memoryCache.Set(CommentCasheKey, model, casheOptions);
                }
                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна непредвидена грешка";
                return RedirectToAction("Error", "Home");
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
                return this.RedirectToAction("All", "Comment", new { area = "Admin" });
            }

            try
            {
                await this.commentService.DeleteCommentAsync(commentId);
                this.memoryCache.Remove(CommentCasheKey);
                return this. RedirectToAction("All", "Comment", new { area = "Admin" });
            }
            catch (Exception)
            {
                return this.RedirectToAction("Index", "Home");
            }
        }
    }
}