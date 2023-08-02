namespace ArtGallery.Services.Data.Interfaces
{
    using Web.ViewModels.OrderAPicture;

    public interface IOrderAPictureService
    {
        /// <summary>
        /// Взимане на всички поръчки
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MyOrdersViewModel>> AllAsync();

        /// <summary>
        /// Добавяне на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <returns></returns>
        Task AddAsync(OrderAPictureFormModel model, string userId);

        /// <summary>
        /// Преглед на мои поръчки
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <returns></returns>
        Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string userId);

        /// <summary>
        /// Изтриване на поръчка
        /// </summary>
        /// <param name="orderId">Идентификатор на поръчката</param>
        /// <returns></returns>
        Task DeleteOrderByIdAsync(int orderId);
    }
}
