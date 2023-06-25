namespace ArtGallery.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static ArtGallery.Common.EntityValidationConstants.Comment;

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
        public string Username { get; set; } = null!;
        
        /// <summary>
        /// Съдържание на коментара.
        /// </summary>
        [Comment("Съдържание на коментара")]
        [Required]
        [MaxLength(CommentMaxLength)]
        public string Content { get; set; } = null!;
    }
}