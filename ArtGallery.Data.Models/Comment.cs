namespace ArtGallery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    using static Common.EntityValidationConstants.Comment;

    /// <summary>
    /// Коментар към картината.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Идентификатор на коментара.
        /// </summary>
        [Comment("Идентификатор на коментара")]
        [Key]
        public int CommentId { get; set; }

        /// <summary>
        /// Име на коментиращият
        /// </summary>
        [Comment("Име на коментиращият")]
        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; } = null!;
        
        /// <summary>
        /// Съдържание на коментара.
        /// </summary>
        [Comment("Съдържание на коментара")]
        [Required]
        [MaxLength(CommentMaxLength)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Идентификатор на картината
        /// </summary>
        [Comment("Идентификатор на картината")]
        public int PictureId { get; set; }

        [ForeignKey(nameof(PictureId))]
        public virtual Picture Picture { get; set; }
    }
}