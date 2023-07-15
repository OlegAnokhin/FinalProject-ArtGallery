namespace ArtGallery.Web.ViewModels.ArtEvent
{
    using System.ComponentModel.DataAnnotations;

    public class AllArtEventViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на обучението
        /// </summary>
        [Display(Name = "Име на обучението")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Адреса на изображинието
        /// </summary>
        [Display(Name = "Адреса на изображението")]
        public string ImageAddress { get; set; } = null!;

        /// <summary>
        /// Начало на обучението
        /// </summary>
        [Display(Name = "Начало на обучението")]
        public DateTime Start { get; set; }
    }
}