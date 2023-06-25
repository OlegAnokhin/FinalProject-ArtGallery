namespace ArtGallery.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Category;
    
    /// <summary>
    /// Изложба
    /// </summary>
    [Comment("Изложба")]
    public class Category
    {
        public Category()
        {
            Pictures = new HashSet<Picture>();
        }

        /// <summary>
        /// Идентификатор на категорията
        /// </summary>
        [Comment("Идентификатор на категорията")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Име на категория на картината
        /// </summary>
        [Comment("Име на категория на картината")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Picture> Pictures { get; set; }
    }
}
