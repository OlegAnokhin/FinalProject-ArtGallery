namespace ArtGallery.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Comment;

    public class CommentViewModel
    {
        [Key]
        public int PictureId { get; set; }

        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Content { get; set; } = null!;
    }
}