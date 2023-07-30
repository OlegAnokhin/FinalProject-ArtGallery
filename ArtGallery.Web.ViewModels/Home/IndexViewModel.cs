namespace ArtGallery.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int  Id { get; set; }

        /// <summary>
        /// Заглавие на картината
        /// </summary>
        public string PictureTitle { get; set; } = null!;

        /// <summary>
        /// Адреса на изображение на картината
        /// </summary>
        public string PictureImageUrl { get; set; } = null!;
        
        ///// <summary>
        ///// Заглавие на АртЕвент
        ///// </summary>
        //public string ArtEventTitle { get; set; } = null!;

        ///// <summary>
        ///// Адреса на изображение на АртЕвента
        ///// </summary>
        //public string ArtEventImageUrl { get; set; } = null!;


    }
}