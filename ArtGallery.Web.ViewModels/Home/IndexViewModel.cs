namespace ArtGallery.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int  Id { get; set; }

        /// <summary>
        /// Име на картината
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Адреса на изображение
        /// </summary>
        public string ImageUrl { get; set; } = null!;
    }
}