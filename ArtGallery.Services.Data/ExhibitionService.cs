using ArtGallery.Data.Models;

namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Data;
    using Web.ViewModels.Exhibition;
    using Interfaces;

    /// <summary>
    /// Услуга за управление на събития
    /// </summary>
    public class ExhibitionService : IExhibitionService
    {
        /// <summary>
        /// Достъп до база данни
        /// </summary>
        private readonly ArtGalleryDbContext context;

        /// <summary>
        /// Инжектиране на зависимост
        /// </summary>
        /// <param name="context">Достъп до база данни</param>
        public ExhibitionService(ArtGalleryDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Прeглед на всички събития
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AllExhibitionsViewModel>> GetAllAsync()
        {
            return await context.Exhibitions
                .Select(e => new AllExhibitionsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    ImageUrl = e.ImageUrl,
                    Place = e.Place
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }

        /// <summary>
        /// Добавяне на събитие
        /// </summary>
        /// <param name="model">Данни за събитие</param>
        /// <returns></returns>
        public async Task AddAsync(ExhibitionFormModel model)
        {
            var exhibition = new Exhibition
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Start = model.Start,
                End = model.End,
                Place = model.Place,
                Description = model.Description
            };
            await context.Exhibitions.AddAsync(exhibition);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int exhibitionId)
        {
            bool result = await context.Exhibitions
                .AnyAsync(e => e.Id == exhibitionId);
            return result;
        }

        /// <summary>
        /// Преглед на изложбата
        /// </summary>
        /// <param name="id">Идентификатор на изложбата</param>
        /// <returns></returns>
        public async Task<DetailsExhibitionsViewModel> GetExhibitionDetailsAsync(int id)
        {
            Exhibition exhibition = await this.context
                .Exhibitions
                .FirstAsync(e => e.Id == id);

            return new DetailsExhibitionsViewModel
            {
                Id = exhibition.Id,
                Name = exhibition.Name,
                ImageUrl = exhibition.ImageUrl,
                Start = exhibition.Start,
                Place = exhibition.Place,
                End = exhibition.End,
                Description = exhibition.Description
            };
        }

        //        /// <summary>
        //        /// Изтриване на събитие
        //        /// </summary>
        //        /// <param name="id">Идентификатор на събитие</param>
        //        /// <returns></returns>
        //        public async Task DeleteAsync(int id)
        //        {
        //            await repo.DeleteAsync<Event>(id);
        //            await repo.SaveChangesAsync();
        //        }

        //        /// <summary>
        //        /// Промяна на събитие
        //        /// </summary>
        //        /// <param name="model">Данни за събитие</param>
        //        /// <returns></returns>
        //        public async Task UpdateAsync(EventModel model)
        //        {
        //            var entity = await repo.GetByIdAsync<Event>(model.Id);
        //            if (entity == null)
        //            {
        //                throw new ArgumentException("Невалиден идентификатор", nameof(model.Id));
        //            }
        //            entity.Name = model.Name;
        //            entity.Start = model.Start;
        //            entity.End = model.End;
        //            entity.Place = model.Place;
        //            entity.Description = model.Description;

        //            await repo.SaveChangesAsync();
        //        }

    }
}
