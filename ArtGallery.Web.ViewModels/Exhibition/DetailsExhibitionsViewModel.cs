namespace ArtGallery.Web.ViewModels.Exhibition
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DetailsExhibitionsViewModel : AllExhibitionsViewModel
    {
        /// <summary>
        /// Край на изложбата
        /// </summary>
        [Display(Name = "Края на изложбата")]
        public DateTime End { get; set; }

        /// <summary>
        /// Описание на изложбата
        /// </summary>
        [Display(Name = "Описание на изложбата")]
        public string Description { get; set; } = null!;
    }
}