namespace ArtGallery.Web.ViewModels.Exhibition
{
    using System.ComponentModel.DataAnnotations;

    public class AllExhibitionsViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на изложбата
        /// </summary>
        [Display(Name = "Име на изложбата")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Адреса на изображинието
        /// </summary>
        [Display(Name = "Адреса на изображинието")]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Начало на изложбата
        /// </summary>
        [Display(Name = "Начало на изложбата")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Мястото на изложбата
        /// </summary>
        [Display(Name = "Мястото на изложбата")]
        public string Place { get; set; } = null!;
    }
}