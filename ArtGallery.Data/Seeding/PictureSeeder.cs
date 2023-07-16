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
                Material = "Акварел",
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
                Material = "Акварел",
                ImageAddress = "\\lib\\images\\Girl2.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче със синя шапка",
            };
            pictures.Add(currentPicture);

            currentPicture = new Picture
            {
                Id = 3,
                Name = "Момиче със зелена шапка",
                Size = "40 х 60",
                Material = "Акварел",
                ImageAddress = "\\lib\\images\\Girl3.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче със зелена шапка",
            };
            pictures.Add(currentPicture);

            return pictures.ToArray();
        }
    }
}
