namespace ArtGallery.Services.Data
{
    using ArtGallery.Data;
    using ArtGallery.Services.Data.Interfaces;

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
        public OrderAPictureService(ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
