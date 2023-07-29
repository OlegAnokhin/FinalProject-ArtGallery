namespace ArtGallery.Web.ViewModels.OrderAPicture
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class MyOrdersViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Вашите имена
        /// </summary>
        [Display(Name = "Вашите имена")]
        public string Fullname { get; set; } = null!;

        /// <summary>
        /// Вашият телефонен номер
        /// </summary>
        [Display(Name = "Вашият телефонен номер")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Размер на картината
        /// </summary>
        [Display(Name = "Желаният размер на картината")]
        public string Size { get; set; } = null!;

        /// <summary>
        /// С какво е нарисувана картината
        /// </summary>
        [Display(Name = "С каква боя желаете да бъде нарисувана картината")]
        public string Material { get; set; } = null!;

        /// <summary>
        /// Върху какво е нарисувана картината
        /// </summary>
        [Display(Name = "Върху какво желаете да бъде нарисувана картината")]
        public string ImageBase { get; set; } = null!;

        /// <summary>
        /// Изображението
        /// </summary>
        [Display(Name = "Добавете изображението")]
        public byte[] Image { get; set; }


        /// <summary>
        /// Описание на картината
        /// </summary>
        [Display(Name = "Описание на картината")]
        public string Description { get; set; } = null!;
    }
}