namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.Comment;

    public interface ICommentService
    {
        /// <summary>
        /// Взимане всички на коментарите
        /// </summary>
        /// <param name="id">Идентификатор на картината</param>
        /// <returns></returns>
        Task<IEnumerable<CommentViewModel>> AllCommentsAsync(int id);

        /// <summary>
        /// Добавяне на коментар
        /// </summary>
        /// <param name="pictureId">Идентификатор на картината</param>
        /// <param name="model">Данни за коментара</param>
        /// <returns></returns>
        Task AddCommentAsync(int pictureId, CommentViewModel model);
    }
}