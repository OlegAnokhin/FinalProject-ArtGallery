namespace ArtGallery.Services.Tests
{
    using ArtGallery.Data;
    using ArtGallery.Data.Models;

    public class DatabaseSeeder
    {
        public static ArtEvent artEvent;

        public static void SeedDatabase(ArtGalleryDbContext dbContext)
        {
            artEvent = new ArtEvent
            {
                Name = "Розовото дърво",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
            };

            dbContext.ArtEvents.Add(artEvent);
            dbContext.SaveChanges();
        }

    }
}
