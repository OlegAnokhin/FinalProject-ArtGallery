namespace ArtGallery.Data.Seeding
{
    using Models;

    class ArtEventSeeder
    {
        internal ArtEvent[] GenerateArtEvents()
        {
            ICollection<ArtEvent> artEvents = new HashSet<ArtEvent>();
            ArtEvent currentArtEvent;

            currentArtEvent = new ArtEvent
            {
                Id = 1,
                Name = "Розовото дърво",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = new DateTime(2023,9,26,17,0,0),
                Place = "Варна, Галерията на Петя",
                Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
            };
            artEvents.Add(currentArtEvent);

            currentArtEvent = new ArtEvent
            {
                Id = 2,
                Name = "Коте с кафе",
                ImageAddress = "\\lib\\images\\ArtEventCatWithCoffee.jpg",
                Start = new DateTime(2023, 9, 27, 17, 0, 0),
                Place = "Варна, Галерията на Петя",
                Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
            };
            artEvents.Add(currentArtEvent);

            currentArtEvent = new ArtEvent
            {
                Id = 3,
                Name = "Куче художник",
                ImageAddress = "\\lib\\images\\ArtEventDogWithBrush.jpg",
                Start = new DateTime(2023, 9, 28, 17, 0, 0),
                Place = "Варна, Галерията на Петя",
                Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
            };
            artEvents.Add(currentArtEvent);
            return artEvents.ToArray();
        }
    }
}