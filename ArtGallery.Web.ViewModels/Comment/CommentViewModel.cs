namespace ArtGallery.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Comment;

    public class CommentViewModel
    {
        /// <summary>
        /// Идентификатор на коментара
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// Идентификатор на картината
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Име на потребителя
        /// </summary>
        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Съобщението
        /// </summary>
        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Content { get; set; } = null!;
    }
}