namespace ArtGallery.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.ArtClass;

    /// <summary>
    /// Обучение
    /// </summary>
    [Comment("Обучение")]
    public class ArtEvent
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Comment("Идентификатор")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Име на обучението
        /// </summary>
        [Comment("Име на обучението")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Начало на обучението
        /// </summary>
        [Comment("Начало на обучението")]
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// Адреса на изображението
        /// </summary>
        [Comment("Адреса на изображението")]
        [Required]
        [MaxLength(ImageAddressMaxLength)]
        public string ImageAddress { get; set; } = null!;

        /// <summary>
        /// Мястото на обучението
        /// </summary>
        [Comment("Мястото на обучението")]
        [Required]
        [MaxLength(PlaceMaxLength)]
        public string Place { get; set; } = null!;

        /// <summary>
        /// Описание на обучението
        /// </summary>
        [Comment("Описание на обучението")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Коментари към обучението
        /// </summary>
        [Comment("Коментари към обучението")]
        public virtual ICollection<Comment> EventComments { get; set; }

        /// <summary>
        /// Списък със записали се
        /// </summary>
        [Comment("Списък със записали се")]
        public virtual ICollection<AppUser> Participants { get; set; }

    }
}
