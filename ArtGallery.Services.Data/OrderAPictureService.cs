namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Data;
    using ArtGallery.Data.Models;
    using Interfaces;
    using Web.ViewModels.OrderAPicture;

    /// <summary>
    /// Услуга за поръчване на картини
    /// </summary>
    public class OrderAPictureService : IOrderAPictureService
    {
        /// <summary>
        /// Достъп до база данни
        /// </summary>
        private readonly ArtGalleryDbContext dbContext;
        /// <summary>
        /// Инжектиране на зависимост
        /// </summary>
        /// <param name="dbContext">Достъп до база данни</param>
        public OrderAPictureService(
            ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Добавяне на поръчка
        /// </summary>
        /// <param name="model">Модел на поръчката</param>
        /// <returns></returns>
        public async Task AddAsync(OrderAPictureFormModel model)
        {
            OrderAPicture order = new OrderAPicture
            {
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Size = model.Size,
                Material = model.Material,
                ImageBase = model.ImageBase,
                Description = model.Description
            };

            using (var memoryStream = new MemoryStream())
            {
                {
                    await model.Image.CopyToAsync(memoryStream);
                    order.ImageData = memoryStream.ToArray();
                }
            }
            order.FileName = model.Image.FileName;

            await dbContext.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Преглед на мои поръчки
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync()
        {
            return await this.dbContext.OrdersAPictures
                .Select(o => new MyOrdersViewModel
                {
                    Id = o.Id,
                    FullName = o.FullName,
                    PhoneNumber = o.PhoneNumber,
                    Size = o.Size,
                    Material = o.Material,
                    ImageBase = o.ImageBase,
                    Image = o.ImageData,
                    Description = o.Description
                }).ToListAsync();
        }
    }
}
