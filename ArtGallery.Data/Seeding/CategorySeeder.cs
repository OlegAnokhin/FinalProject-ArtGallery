namespace ArtGallery.Data.Seeding
{
    using Models;

    class CategorySeeder
    {
        internal Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();
            Category currentCategory;

            currentCategory = new Category()
            {
                Id = 1,
                Name = "Животни"
            };
            categories.Add(currentCategory);

            currentCategory = new Category()
            {
                Id = 2,
                Name = "Хора"
            };            
            categories.Add(currentCategory);

            currentCategory = new Category()
            {
                Id = 3,
                Name = "Къщи"
            };
            categories.Add(currentCategory);

            currentCategory = new Category()
            {
                Id = 4,
                Name = "Пейзаж"
            };
            categories.Add(currentCategory);

            return categories.ToArray();
        }
    }
}