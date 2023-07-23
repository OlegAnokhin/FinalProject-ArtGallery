//namespace ArtGallery.Data.Models
//{
//    using Microsoft.EntityFrameworkCore;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;

//    /// <summary>
//    /// Свързваща таблица на картини с коментари
//    /// </summary>
//    public class PictureComment
//    {
//        /// <summary>
//        /// Идентификатор на картината
//        /// </summary>
//        [Comment("Идентификатор на картината")]
//        [Key]
//        public int PictureId { get; set; }

//        [ForeignKey(nameof(PictureId))]
//        public Picture Picture { get; set; } = null!;

//        /// <summary>
//        /// Идентификатор на коментар
//        /// </summary>
//        [Comment("Идентификатор на коментар")]
//        [Key]
//        public int CommentId { get; set; }

//        [ForeignKey(nameof(CommentId))]
//        public Comment Comment { get; set; } = null!;
//    }
//}