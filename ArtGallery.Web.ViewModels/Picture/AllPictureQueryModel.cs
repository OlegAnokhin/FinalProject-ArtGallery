namespace ArtGallery.Web.ViewModels.Picture
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GeneralAppConstants;
    public class AllPictureQueryModel
    {
        public AllPictureQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.PicturesPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Pictures = new HashSet<AllPictureViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Търсене по име")]
        public string? SearchString { get; set; }

        [Display(Name = "Подреди картините по")]
        public PictureSorting PictureSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Покажи по ")]
        public int PicturesPerPage { get; set; }

        public int TotalHouses { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<AllPictureViewModel> Pictures { get; set; }
    }
}