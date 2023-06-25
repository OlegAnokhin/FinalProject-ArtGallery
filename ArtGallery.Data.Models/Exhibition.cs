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
        [Key]
        [Comment("Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Име на изложбата
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Име на изложбата")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Начало на изложбата
        /// </summary>
        [Required]
        [Comment("Начало на изложбата")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Край на изложбата
        /// </summary>
        [Required]
        [Comment("Край на изложбата")]
        public DateTime End { get; set; }

        /// <summary>
        /// Мястото на изложбата
        /// </summary>
        [Required]
        [MaxLength(PlaceMaxLength)]
        [Comment("Мястото на изложбата")]
        public string Place { get; set; } = null!;

        /// <summary>
        /// Описание на изложбата
        /// </summary>
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Описание на изложбата")]
        public string Description { get; set; } = null!;
    }
}
