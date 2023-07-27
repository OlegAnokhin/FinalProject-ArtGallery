﻿namespace ArtGallery.Web.Controllers
{
    using ArtGallery.Services.Data;
    using ArtGallery.Web.Infrastucture.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using System.Security.Claims;
    using ViewModels.Comment;

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

        [HttpGet]
        public IActionResult Add([FromRoute]int id)
        {
            var model = new CommentViewModel { PictureId = id };
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int pictureId, CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError("Възникна непредвидена грешка");
                return this.RedirectToAction("All", "Picture");
            }

            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!user.Any())
            {
                logger.LogError("Потребител не съществува");

                return this.RedirectToAction("All", "Picture");
            }

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

            return this.RedirectToAction("Details", "Picture", new { id = pictureId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!User.IsAdmin())
            {
                return this.RedirectToAction("Error", "Home", StatusCode(401));
            }
            bool commentExist = await commentService.ExistsByIdAsync(id);

            if (!commentExist)
            {
                logger.LogError("Коментар с такъв идентификатор не съществува.");
                return this.RedirectToAction("All", "Picture");
            }

            try
            {
                await this.commentService.DeleteCommentAsync(id);
                return this.RedirectToAction("All", "Picture");
            }
            catch (Exception e)
            {
                logger.LogError("Възникна непредвидена грешка", e);
                return this.RedirectToAction("All", "Picture");
            }
        }
    }
}