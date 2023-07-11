namespace ArtGallery.Web.ViewModels.Picture
{
    using System.ComponentModel.DataAnnotations;

    using Enums;
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

        /// <summary>
        /// Категория
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Търсене по име на картината
        /// </summary>
        [Display(Name = "Търсене по име")]
        public string? SearchString { get; set; }

        /// <summary>
        /// Подреждане на картинете по
        /// </summary>
        [Display(Name = "Подреди картините по")]
        public PictureSorting PictureSorting { get; set; }

        /// <summary>
        /// Сегащна страница
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Списък с количество картини на страница
        /// </summary>
        [Display(Name = "Покажи по ")]
        public int PicturesPerPage { get; set; }

        /// <summary>
        /// Число на всички картини
        /// </summary>
        public int TotalPictures { get; set; }

        /// <summary>
        /// Колекция на всички категории
        /// </summary>
        public IEnumerable<string> Categories { get; set; }

        /// <summary>
        /// Колекция на всички картини
        /// </summary>
        public IEnumerable<AllPictureViewModel> Pictures { get; set; }
    }
}