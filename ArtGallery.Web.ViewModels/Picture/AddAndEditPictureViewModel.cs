namespace ArtGallery.Web.ViewModels.Picture
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Picture;

    public class AddAndEditPictureViewModel
    {
        public AddAndEditPictureViewModel()
        {
            this.Categories = new HashSet<PictureSelectCategoryModel>();
        }
        /// <summary>
        /// Име на картината
        /// </summary>
        [Display(Name = "Име на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Размер на картината
        /// </summary>
        [Display(Name = "Размер на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(SizeMaxLength, MinimumLength = SizeMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Size { get; set; } = null!;

        /// <summary>
        /// С какво е нарисувана картината
        /// </summary>
        [Display(Name = "С какво е нарисувана картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(MaterialMaxLength, MinimumLength = MaterialMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Material { get; set; } = null!;

        /// <summary>
        /// Адреса на изображението
        /// </summary>
        [Display(Name = "Адреса на изображението")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(ImageAddressMaxLength, MinimumLength = ImageAddressMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string ImageAddress { get; set; } = null!;

        /// <summary>
        /// Платното на картината
        /// </summary>
        [Display(Name = "Платното на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(ImageBaseMaxLength, MinimumLength = ImageBaseMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string ImageBase { get; set; } = null!;

        /// <summary>
        /// Категория на картината
        /// </summary>
        [Display(Name = "Категория на картината")]
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория на картината
        /// </summary>
        [Display(Name = "Категория на картината")]
        [Required]
        public IEnumerable<PictureSelectCategoryModel> Categories { get; set; }

        /// <summary>
        /// Описание на картината
        /// </summary>
        [Display(Name = "Описание на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Дата на създаване на картината
        /// </summary>
        [Display(Name = "Дата на създаване на картината")]
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}