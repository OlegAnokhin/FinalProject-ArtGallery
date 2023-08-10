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
        /// Взимане на всички поръчки
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MyOrdersViewModel>> AllAsync()
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
                })
                .ToListAsync();
        }

        /// <summary>
        /// Добавяне на картина
        /// </summary>
        /// <param name="model">Данни за картина</param>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <returns></returns>
        public async Task AddAsync(OrderAPictureFormModel model, string userId)
        {
            OrderAPicture order = new OrderAPicture
            {
                UserId = userId,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Size = model.Size,
                Material = model.Material,
                ImageBase = model.ImageBase,
                Description = model.Description
            };

            if (model.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    {
                        await model.Image.CopyToAsync(memoryStream);
                        order.ImageData = memoryStream.ToArray();
                    }
                }

                order.FileName = model.Image.FileName;
            }

            if (model.Image == null)
            {
                order.FileName = "Няма изображение";
            }

            await dbContext.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Преглед на мои поръчки
        /// </summary>
        /// <param name="userId">Идентификатор на потребителя</param>
        /// <returns></returns>
        public async Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string userId)
        {
            return await this.dbContext.OrdersAPictures
                .Where(o => o.UserId == userId)
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
                })
                .ToListAsync();
        }

        /// <summary>
        /// Изтриване на поръчка
        /// </summary>
        /// <param name="orderId">Идентификатор на поръчката</param>
        /// <returns></returns>
        public async Task DeleteOrderByIdAsync(int orderId)
        {
            OrderAPicture order = await this.dbContext.OrdersAPictures
                .FirstAsync(o => o.Id == orderId);

            dbContext.OrdersAPictures.Remove(order);
            await dbContext.SaveChangesAsync();
        }
    }
}