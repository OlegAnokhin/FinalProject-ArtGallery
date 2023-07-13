namespace ArtGallery.Web.ViewModels.ArtEvent
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ArtClass;

    public class ArtEventFormModel
    {
        /// <summary>
        /// Име на обучението
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [Display(Name = "Име на обучението")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Адреса на изображинието
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [Display(Name = "Адреса на изображението")]
        [StringLength(ImageAddressMaxLength, MinimumLength = ImageAddressMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string ImageAddress { get; set; } = null!;

        /// <summary>
        /// Начало на обучението
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [Display(Name = "Начало на обучението")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Мястото на обучението
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [Display(Name = "Мястото на обучението")]
        [StringLength(PlaceMaxLength, MinimumLength = PlaceMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Place { get; set; } = null!;

        /// <summary>
        /// Описание на обучението
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [Display(Name = "Описание на обучението")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
    }
}