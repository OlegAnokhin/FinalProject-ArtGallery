namespace ArtGallery.Services.Data.Models.Picture
{
    using Web.ViewModels.Picture;

    public class AllPicturesFilteredAndPagedServiceModel
    {
        public AllPicturesFilteredAndPagedServiceModel()
        {
            this.Pictures = new HashSet<AllPictureViewModel>();
        }

        public int TotalPicturesCount { get; set; }

        public IEnumerable<AllPictureViewModel> Pictures { get; set; }
    }
}