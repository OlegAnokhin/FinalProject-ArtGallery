namespace ArtGallery.Data.Models
{

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Picture;

    /// <summary>
    /// Картинa
    /// </summary>
    [Comment("Картинa")]
    public class Picture
    {
        public Picture()
        {
            PictureComments = new HashSet<Comment>();
        }
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Comment("Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Име на картината
        /// </summary>
        [Comment("Име на картината")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Размер на картината
        /// </summary>
        [Comment("Размер на картината")]
        [Required]
        [MaxLength(SizeMaxLength)]
        public string Size { get; set; } = null!;

        /// <summary>
        /// С какво е нарисувана картината
        /// </summary>
        [Comment("С какво е нарисувана картината")]
        [Required]
        [MaxLength(MaterialMaxLength)]
        public string Material { get; set; } = null!;

        /// <summary>
        /// Адреса на изображението
        /// </summary>
        [Comment("Адреса на изображението")]
        [Required]
        [MaxLength(ImageAddressMaxLength)]
        public string ImageAddress { get; set; } = null!;

        /// <summary>
        /// Върху какво е нарисувана картината
        /// </summary>
        [Comment("Върху какво е нарисувана картината")]
        [Required]
        [MaxLength(ImageBaseMaxLength)]
        public string ImageBase { get; set; } = null!;

        /// <summary>
        /// Идентификатор на категорията
        /// </summary>
        [Comment("Идентификатор на категорията")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория на картината
        /// </summary>
        [Comment("Категория на картината")]
        [Required]
        [MaxLength(CategoryMaxLength)]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Описание на картината
        /// </summary>
        [Comment("Описание на картината")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Дата на създаване на картината
        /// </summary>
        [Comment("Дата на създаване на картината")]
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Коментари към картината
        /// </summary>
        [Comment("Коментари към картината")]
        public virtual ICollection<Comment>PictureComments { get; set; }
    }
}