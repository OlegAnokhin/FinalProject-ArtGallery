namespace ArtGallery.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    using Common;
    using static Common.EntityValidationConstants.OrderAPicture;

    /// <summary>
    /// Таблица за поръчване на картина
    /// </summary>
    public class OrderAPicture
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Comment("Идентификатор")]
        public int Id { get; set; }

        [Comment("Идентификатор на потребителя")]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        /// <summary>
        /// Име на заявка
        /// </summary>
        [Comment("Име на заявка")]
        [Required]
        public string FileName { get; set; } = null!;

        /// <summary>
        /// Вашите имена
        /// </summary>
        [Comment("Вашите имена")]
        [Required]
        [MaxLength(FullnameMaxLength)]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Вашият телефонен номер
        /// </summary>
        [Comment("Вашият телефонен номер")]
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Размер на картината
        /// </summary>
        [Comment("Желаният размер на картината")]
        [Required]
        [MaxLength(SizeMaxLength)]
        public string Size { get; set; } = null!;

        /// <summary>
        /// С какво е нарисувана картината
        /// </summary>
        [Comment("С каква боя желаете да бъде нарисувана картината")]
        [Required]
        [MaxLength(MaterialMaxLength)]
        public string Material { get; set; } = null!;

        /// <summary>
        /// Върху какво е нарисувана картината
        /// </summary>
        [Comment("Върху какво желаете да бъде нарисувана картината")]
        [Required]
        [MaxLength(ImageBaseMaxLength)]
        public string ImageBase { get; set; } = null!;

        /// <summary>
        /// Описание на картината
        /// </summary>
        [Comment("Допълнителни желания към картината")]
        [Required]
       // [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Изображението
        /// </summary>
        [Comment("Добавете изображението")]
        [MaxByteArraySize(ImageMaxSize)]
        public byte[] ImageData { get; set; }

    }
}