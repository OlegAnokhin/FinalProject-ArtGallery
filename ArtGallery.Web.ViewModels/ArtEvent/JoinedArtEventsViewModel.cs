namespace ArtGallery.Web.ViewModels.ArtEvent
{
    using System.ComponentModel.DataAnnotations;

    public class JoinedArtEventsViewModel
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