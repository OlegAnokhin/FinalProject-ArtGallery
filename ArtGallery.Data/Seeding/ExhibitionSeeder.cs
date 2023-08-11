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
                Start = new DateTime(2023,9,20,10,0,0),
                End = new DateTime(2023,9,30,17,0,0),
                Place = "Варна, Галерията на Петя",
                Description = "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни."
            };

            exhibitions.Add(currentExhibition);

            return exhibitions.ToArray();
        }
    }
}