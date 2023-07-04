namespace ArtGallery.Web.ViewModels.Picture
{
    public class PictureSelectCategoryModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на категорията
        /// </summary>
        public string Name { get; set; } = null!;
    }
}