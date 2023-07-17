﻿namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using ArtGallery.Data;
    using ArtGallery.Data.Models;
    using Web.ViewModels.Comment;

    /// <summary>
    /// Услуга за управление на коментари
    /// </summary>
    public class CommentService : ICommentService
    {
            /// <summary>
            /// Достъп до база данни
            /// </summary>
            private readonly ArtGalleryDbContext dbContext;

            /// <summary>
            /// Инжектиране на зависимост
            /// </summary>
            /// <param name="dbContext">Достъп до база данни</param>
            public CommentService(ArtGalleryDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            /// <summary>
            /// Добавяне на коментар
            /// </summary>
            /// <param name="model">Данни за коментара</param>
            /// <returns></returns>
            public async Task AddAsync(CommentViewModel model, string userId, int pictureId)
            {
                Comment comment = new Comment()
                {
                    
                    Username = model.Username,
                    Content = model.Content
                };

                await dbContext.AddAsync(comment);
                await dbContext.SaveChangesAsync();
            }

            /// <summary>
            /// Взимане на всички коментари
            /// </summary>
            /// <returns></returns>
            public async Task<IEnumerable<CommentViewModel>> AllCommentsAsync(int pictureId)
            {
                IEnumerable<CommentViewModel> allComments = await this.dbContext
                    .PicturesComment
                    .Include(c => c.Comment)
                    .Where(p => p.PictureId == pictureId)
                    .Select(c => new CommentViewModel()
                    {
                        Username = c.Comment.Username,
                        Content = c.Comment.Content
                    }).ToArrayAsync();

                return allComments;
            }
    }
}