namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.Comment;

    public interface ICommentService
    {
        /// <summary>
        /// Добавяне на коментар
        /// </summary>
        /// <param name="model">Данни за коментара</param>
        /// <returns></returns>
        Task AddAsync(CommentViewModel model, string userId, int pictureId);

        /// <summary>
        /// Взимане всички на коментарите
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommentViewModel>> AllCommentsAsync(int id);

    }
}
