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
        Task AddAsync(CommentViewModel model);

        /// <summary>
        /// Взимане на коментарите
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommentViewModel>> AllCommentsAsync();

    }
}
