namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.OrderAPicture;

    public interface IOrderAPictureService
    {
        /// <summary>
        /// Добавяне на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <returns></returns>
        Task AddAsync(OrderAPictureFormModel model);

    }
}
