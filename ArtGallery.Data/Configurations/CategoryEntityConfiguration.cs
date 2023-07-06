namespace ArtGallery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using Seeding;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly CategorySeeder seeder;
        public CategoryEntityConfiguration()
        {
            this.seeder = new CategorySeeder();
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.seeder.GenerateCategories);
        }
    }
}