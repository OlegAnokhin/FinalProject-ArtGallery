namespace ArtGallery.Web.ViewModels.Picture
{
    using System.ComponentModel.DataAnnotations;

    public class AllPictureViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на картината
        /// </summary>
        [Display(Name = "Име на картината")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Адреса на изображението
        /// </summary>
        [Display(Name = "Адреса на изображението")]
        public string ImageAddress { get; set; } = null!;
    }
}