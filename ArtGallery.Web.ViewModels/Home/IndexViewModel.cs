namespace ArtGallery.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        /// <summary>
        /// Заглавие на АртЕвент
        /// </summary>
        public string ArtEventTitle { get; set; } = null!;

        /// <summary>
        /// Адреса на изображение на АртЕвента
        /// </summary>
        public string ArtEventImageUrl { get; set; } = null!;

        /// <summary>
        /// Колекция от картини
        /// </summary>
        public List<PictureInfo> PicturesInfo { get; set; } = new List<PictureInfo>();
    }
}