namespace ArtGallery.Web.ViewModels.ArtEvent
{
    public class AllArtEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageAddress { get; set; } = null!;

        public DateTime Start { get; set; }
    }
}