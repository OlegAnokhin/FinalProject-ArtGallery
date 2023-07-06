namespace ArtGallery.Web.ViewModels.Picture.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum PictureSorting
    {
        [Display(Name = "Последно добавени")]
        Newest = 0,
        [Display(Name = "Първо добавени")]
        Oldest = 1
    }
}