namespace ArtGallery.Services.Data
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
        /// Взимане на всички коментари
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CommentViewModel>> AllCommentsAsync(int pictureId)
        {
            var picture = await this.dbContext
                .Pictures
                .FirstAsync(p => p.Id == pictureId);

            return picture.PictureComments
                .Select(c => new CommentViewModel()
                {
                    Username = c.Username,
                    Content = c.Content
                }).ToArray();
        }

        /// <summary>
        /// Добавяне на коментар
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <param name="model">Данни за коментара</param>
        /// <returns></returns>
        public async Task AddCommentAsync(int pictureId, CommentViewModel model)
        {
            var picture = await this.dbContext
                .Pictures
                .FirstAsync(p => p.Id == pictureId);

            Comment comment = new Comment()
            {
                Username = model.Username,
                Content = model.Content
            };

            picture.PictureComments.Add(comment);

            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
        }
    }
}