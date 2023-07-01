namespace ArtGallery.Web.ViewModels.Picture
{
    public class AllPictureViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}