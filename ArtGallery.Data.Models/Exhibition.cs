namespace ArtGallery.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Exhibition;

    /// <summary>
    /// Изложба
    /// </summary>
    [Comment("Изложба")]
    public class Exhibition
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Comment("Идентификатор")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Име на изложбата
        /// </summary>
        [Comment("Име на изложбата")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Адреса на изображинието
        /// </summary>
        [Comment("Адреса на изображинието")]
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Начало на изложбата
        /// </summary>
        [Comment("Начало на изложбата")]
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// Край на изложбата
        /// </summary>
        [Comment("Край на изложбата")]
        [Required]
        public DateTime End { get; set; }

        /// <summary>
        /// Мястото на изложбата
        /// </summary>
        [Comment("Мястото на изложбата")]
        [Required]
        [MaxLength(PlaceMaxLength)]
        public string Place { get; set; } = null!;

        /// <summary>
        /// Описание на изложбата
        /// </summary>
        [Comment("Описание на изложбата")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}