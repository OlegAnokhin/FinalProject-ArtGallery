namespace ArtGallery.Web.ViewModels.Exhibition
{
    using System.ComponentModel.DataAnnotations;

    public class ExhibitionModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Име на изложбата
        /// </summary>
        [Display(Name = "Име на изложбата")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Начало на изложбата
        /// </summary>
        [Display(Name = "Начало на изложбата")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Край на изложбата
        /// </summary>
        [Display(Name = "Края на изложбата")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime End { get; set; }

        /// <summary>
        /// Мястото на изложбата
        /// </summary>
        [Display(Name = "Мястото на изложбата")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е между {2} и {1} символа")]
        public string Place { get; set; } = null!;

        /// <summary>
        /// Описание на изложбата
        /// </summary>
        [Display(Name = "Описание на изложбата")]
        [StringLength(250)]
        public string? Description { get; set; }
    }
}