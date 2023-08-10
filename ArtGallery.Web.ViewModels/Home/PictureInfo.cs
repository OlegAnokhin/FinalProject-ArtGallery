namespace ArtGallery.Web.ViewModels.Home
{
    public class PictureInfo
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заглавие на картината
        /// </summary>
        public string PictureTitle { get; set; } = null!;

        /// <summary>
        /// Адреса на изображение на картината
        /// </summary>
        public string PictureImageUrl { get; set; } = null!;
    }
}