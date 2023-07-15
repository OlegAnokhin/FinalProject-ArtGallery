namespace ArtGallery.Web.ViewModels.ArtEvent
{
    using System.ComponentModel.DataAnnotations;

    public class DetaisArtEventViewModel : AllArtEventViewModel
    {
        /// <summary>
        /// Мястото на обучението
        /// </summary>
        [Display(Name = "Мястото на обучението")]
        public string Place { get; set; } = null!;

        /// <summary>
        /// Описание на обучението
        /// </summary>
        [Display(Name = "Описание на обучението")]
        public string Description { get; set; } = null!;
    }
}