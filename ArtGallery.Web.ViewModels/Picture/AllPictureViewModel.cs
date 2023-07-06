using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Web.ViewModels.Picture
{
    public class AllPictureViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на картината")]
        public string Name { get; set; } = null!;

        [Display(Name = "Адреса на картината")]
        public string ImageAddress { get; set; } = null!;
    }
}