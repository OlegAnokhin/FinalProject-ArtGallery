namespace ArtGallery.Data.Seeding
{
    using Models;

    class ExhibitionSeeder
    {
        internal Exhibition[] GeneratExhibitions()
        {
            ICollection<Exhibition> exhibitions = new HashSet<Exhibition>();
            Exhibition currentExhibition;

            currentExhibition = new Exhibition
            {
                Id = 1,
                Name = "Изложба Африка",
                ImageUrl = "\\lib\\images\\ExhibitionAfrica.jpg",
                Start = DateTime.Parse("20-07-2023 10:00"),
                End = DateTime.Parse("30-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни."
            };

            exhibitions.Add(currentExhibition);

            return exhibitions.ToArray();
        }
    }
}