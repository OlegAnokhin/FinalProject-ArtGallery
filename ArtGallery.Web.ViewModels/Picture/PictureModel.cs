//namespace ArtGallery.Web.ViewModels.Picture
//{
//    using System.ComponentModel.DataAnnotations;

//    using static Common.EntityValidationConstants.Picture;

//    public class PictureModel
//    {
//        /// <summary>
//        /// Списък с категории
//        /// </summary>
//        public PictureModel()
//        {
//            Categories = new HashSet<PictureSelectCategoryModel>();
//        }

//        /// <summary>
//        /// Идентификатор
//        /// </summary>
//        [Key]
//        public int Id { get; set; }

//        /// <summary>
//        /// Име на картината
//        /// </summary>
//        [Display(Name = "Име на картината")]
//        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
//        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
//        public string Name { get; set; } = null!;

//        /// <summary>
//        /// Размер на картината
//        /// </summary>
//        [Display(Name = "Размер на картината")]
//        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
//        [StringLength(SizeMaxLength, MinimumLength = SizeMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
//        public string Size { get; set; } = null!;

//        /// <summary>
//        /// С какво е нарисувана картината
//        /// </summary>
//        [Display(Name = "С какво е нарисувана картината")]
//        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
//        [StringLength(MaterialMaxLength, MinimumLength = MaterialMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
//        public string Material { get; set; } = null!;

//        /// <summary>
//        /// Адреса на изображението
//        /// </summary>
//        [Display(Name = "Адреса на изображението")]
//        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
//        [StringLength(ImageAddressMaxLength, MinimumLength = ImageAddressMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
//        public string ImageAddress { get; set; } = null!;

//        /// <summary>
//        /// Платното на картината
//        /// </summary>
//        [Display(Name = "Платното на картината")]
//        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
//        [StringLength(ImageBaseMaxLength, MinimumLength = ImageBaseMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
//        public string ImageBase { get; set; } = null!;

//        /// <summary>
//        /// Категория на картината
//        /// </summary>
//        [Display(Name = "Категория на картината")]
//        [Range(1, int.MaxValue)]
//        public int CategoryId { get; set; }

//        /// <summary>
//        /// Категория на картината
//        /// </summary>
//        [Display(Name = "Категория на картината")]
//        public string Category { get; set; }

//        /// <summary>
//        /// Списък с категории
//        /// </summary>
//        public IEnumerable<PictureSelectCategoryModel> Categories { get; set; }

//        /// <summary>
//        /// Описание на картината
//        /// </summary>
//        [Display(Name = "Описание на картината")]
//        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
//        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
//        public string Description { get; set; }

//        /// <summary>
//        /// Дата на картината
//        /// </summary>
//        [Display(Name = "Дата на картината")]
//        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
//        public DateTime Date { get; set; }
//    }
//}