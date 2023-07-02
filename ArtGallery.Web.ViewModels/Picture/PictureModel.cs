namespace ArtGallery.Web.ViewModels.Picture
{
    using System.ComponentModel.DataAnnotations;

    public class PictureModel
    {
        /// <summary>
        /// Списък с категории
        /// </summary>
        public PictureModel()
        {
            Categories = new HashSet<CategoryModel>();
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Име на картината
        /// </summary>
        [Display(Name = "Име на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Размер на картината
        /// </summary>
        [Display(Name = "Размер на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Size { get; set; } = null!;

        /// <summary>
        /// С какво е нарисувана картината
        /// </summary>
        [Display(Name = "С какво е нарисувана картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Material { get; set; } = null!;

        /// <summary>
        /// Адреса на изображението
        /// </summary>
        [Display(Name = "Адреса на изображението")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string ImageAddress { get; set; } = null!;

        /// <summary>
        /// Платното на картината
        /// </summary>
        [Display(Name = "Платното на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string ImageBase { get; set; } = null!;

        /// <summary>
        /// Категория на картината
        /// </summary>
        [Display(Name = "Категория на картината")]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория на картината
        /// </summary>
        [Display(Name = "Категория на картината")]
        public string Category { get; set; }

        /// <summary>
        /// Описание на картината
        /// </summary>
        [Display(Name = "Описание на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Дата на картината
        /// </summary>
        [Display(Name = "Дата на картината")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Списък с категории
        /// </summary>
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}