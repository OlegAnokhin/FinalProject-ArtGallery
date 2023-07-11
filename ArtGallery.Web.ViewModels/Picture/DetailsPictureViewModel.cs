namespace ArtGallery.Web.ViewModels.Picture
{
    using System.ComponentModel.DataAnnotations;
    using Comment;

    public class DetailsPictureViewModel
    {
        /// <summary>
        /// Списък с коментари
        /// </summary>
        public DetailsPictureViewModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на картината
        /// </summary>
        [Display(Name = "Име на картината")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Размер на картината
        /// </summary>
        [Display(Name = "Размер на картината")]
        public string Size { get; set; } = null!;

        /// <summary>
        /// С какво е нарисувана картината
        /// </summary>
        [Display(Name = "С какво е нарисувана картината")]
        public string Material { get; set; } = null!;

        /// <summary>
        /// Адреса на изображението
        /// </summary>
        [Display(Name = "Адреса на изображението")]
        public string ImageAddress { get; set; } = null!;

        /// <summary>
        /// Платното на картината
        /// </summary>
        [Display(Name = "Платното на картината")]
        public string ImageBase { get; set; } = null!;

        /// <summary>
        /// Категория на картината
        /// </summary>
        [Display(Name = "Категория на картината")]
        public string Category { get; set; } = null!;

        /// <summary>
        /// Описание на картината
        /// </summary>
        [Display(Name = "Описание на картината")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Дата на картината
        /// </summary>
        [Display(Name = "Дата на картината")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Колекция на всички коментари
        /// </summary>
        [Display(Name = "Коментари към картината")]
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}