namespace ArtGallery.Web.ViewModels.OrderAPicture
{
    using System.ComponentModel.DataAnnotations;

    using ArtGallery.Common;
    using static Common.EntityValidationConstants.OrderAPicture;

    public class OrderAPictureFormModel
    {
        /// <summary>
        /// Вашите имена
        /// </summary>
        [Display(Name = "Вашите имена")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(FullnameMaxLength, MinimumLength = FullnameMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Fullname { get; set; } = null!;

        /// <summary>
        /// Вашият телефонен номер
        /// </summary>
        [Display(Name = "Вашият телефонен номер")]
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Размер на картината
        /// </summary>
        [Display(Name = "Желаният размер на картината")]
        [Required]
        [StringLength(SizeMaxLength, MinimumLength = SizeMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Size { get; set; } = null!;

        /// <summary>
        /// С какво е нарисувана картината
        /// </summary>
        [Display(Name = "С каква боя желаете да бъде нарисувана картината")]
        [Required]
        [StringLength(MaterialMaxLength, MinimumLength = MaterialMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Material { get; set; } = null!;

        /// <summary>
        /// Върху какво е нарисувана картината
        /// </summary>
        [Display(Name = "Върху какво желаете да бъде нарисувана картината")]
        [Required]
        [StringLength(ImageBaseMaxLength, MinimumLength = ImageBaseMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string ImageBase { get; set; } = null!;

        /// <summary>
        /// Адреса на изображението
        /// </summary>
        [Display(Name = "Добавете изображението")]
        [MaxByteArraySize(ImageMaxSize)]
        public byte[] Image { get; set; }


        /// <summary>
        /// Описание на картината
        /// </summary>
        [Display(Name = "Описание на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Description { get; set; } = null!;
    }
}