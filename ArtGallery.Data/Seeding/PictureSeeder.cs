namespace ArtGallery.Data.Seeding
{
    using Models;

    class PictureSeeder
    {
        internal Picture[] GeneratePictures()
        {
            ICollection<Picture> pictures = new HashSet<Picture>();
            Picture currentPicture;

            currentPicture = new Picture
            {
                Id = 1,
                Name = "Момиче с цвете",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Girl1.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче с цвете в косата",
            };
            pictures.Add(currentPicture);

            currentPicture = new Picture
            {
                Id = 2,
                Name = "Момиче със синя шапка",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Girl2.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче със синя шапка",
            };
            pictures.Add(currentPicture);

            currentPicture = new Picture
            {
                Id = 3,
                Name = "Момиче със оранжева шапка",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Girl3.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче със оранжева шапка",
            };
            pictures.Add(currentPicture);
            
            currentPicture = new Picture
            {
                Id = 4,
                Name = "Конче",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Animal1.jpg",
                ImageBase = "Платно",
                CategoryId = 1,
                Description = "Портрет на кон",
            };
            pictures.Add(currentPicture);
            
            currentPicture = new Picture
            {
                Id = 5,
                Name = "Лъв",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Animal2.jpg",
                ImageBase = "Платно",
                CategoryId = 1,
                Description = "Портрет на царя на животните",
            };
            pictures.Add(currentPicture);
            
            currentPicture = new Picture
            {
                Id = 6,
                Name = "Тигър",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Animal3.jpg",
                ImageBase = "Платно",
                CategoryId = 1,
                Description = "Портрет на тигър",
            };
            pictures.Add(currentPicture);
            
            currentPicture = new Picture
            {
                Id = 7,
                Name = "Три шарени къщички",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\House1.jpg",
                ImageBase = "Платно",
                CategoryId = 3,
                Description = "Три шарени къщички",
            };
            pictures.Add(currentPicture);
            
            currentPicture = new Picture
            {
                Id = 8,
                Name = "Шарени къщички на дърво",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\House2.jpg",
                ImageBase = "Платно",
                CategoryId = 3,
                Description = "Шарени къщички на дърво",
            };
            pictures.Add(currentPicture);
            
            currentPicture = new Picture
            {
                Id = 9,
                Name = "Шарени къщички на колела",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\House3.jpg",
                ImageBase = "Платно",
                CategoryId = 3,
                Description = "Шарени къщички на колела",
            };
            pictures.Add(currentPicture);

            currentPicture = new Picture
            {
                Id = 10,
                Name = "Розово дърво",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Nature1.jpg",
                ImageBase = "Платно",
                CategoryId = 4,
                Description = "Розово дърво",
            };
            pictures.Add(currentPicture);

            currentPicture = new Picture
            {
                Id = 11,
                Name = "Розово дърво на скала",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Nature2.jpg",
                ImageBase = "Платно",
                CategoryId = 4,
                Description = "Розово дърво на скала",
            };
            pictures.Add(currentPicture);

            currentPicture = new Picture
            {
                Id = 12,
                Name = "Бурно море",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Nature3.jpg",
                ImageBase = "Платно",
                CategoryId = 4,
                Description = "Бурно море",
            };
            pictures.Add(currentPicture);

            return pictures.ToArray();
        }
    }
}
