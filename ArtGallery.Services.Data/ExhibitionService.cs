//namespace ArtGallery.Services.Data
//{
//    using Interfaces;
//    using Web.ViewModels.Event;

//    /// <summary>
//    /// Услуга за управление на събития
//    /// </summary>
//    public class EventService : IEventService
//    {
//        /// <summary>
//        /// Достъп до база данни
//        /// </summary>
//        private readonly IRepository repo;

//        /// <summary>
//        /// Инжектиране на зависимост
//        /// </summary>
//        /// <param name="_repo">Достъп до база данни</param>
//        public EventService(IRepository _repo)
//        {
//            repo = _repo;
//        }

//        /// <summary>
//        /// Добавяне на събитие
//        /// </summary>
//        /// <param name="model">Данни за събитие</param>
//        /// <returns></returns>
//        public async Task AddAsync(EventModel model)
//        {
//            Event entity = new Event()
//            {
//                Name = model.Name,
//                Start = model.Start,
//                End = model.End,
//                Place = model.Place,
//                Description = model.Description
//            };
//            await repo.AddAsync(entity);
//            await repo.SaveChangesAsync();
//        }

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

//        /// <summary>
//        /// Пергед на всички събития
//        /// </summary>
//        /// <param name="id">Идентификатор на събитие</param>
//        /// <returns></returns>
//        public async Task<IEnumerable<EventModel>> GetAllAsync()
//        {
//            return await repo.AllReadonly<Event>()
//                .Select(e => new EventModel()
//                {
//                    Id = e.Id,
//                    Name = e.Name,
//                    Start = e.Start,
//                    End = e.End,
//                    Place = e.Place,
//                    Description = e.Description
//                })
//                .OrderBy(e => e.Start)
//                .ToListAsync();
//        }

//        /// <summary>
//        /// Пергед на събитие
//        /// </summary>
//        /// <param name="id">Идентификатор на събитие</param>
//        /// <returns></returns>
//        public async Task<EventModel> GetEventAsync(int id)
//        {
//            var entity = await repo.GetByIdAsync<Event>(id);
//            if (entity == null)
//            {
//                throw new ArgumentException("Невалиден идентификатор", nameof(id));
//            }

//            return new EventModel()
//            {
//                Name = entity.Name,
//                Start = entity.Start,
//                End = entity.End,
//                Place = entity.Place,
//                Description = entity.Description
//            };
//        }
//    }
//}
