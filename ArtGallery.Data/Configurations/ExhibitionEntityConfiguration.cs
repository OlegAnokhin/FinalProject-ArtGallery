namespace ArtGallery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using Seeding;

    public class ExhibitionEntityConfiguration : IEntityTypeConfiguration<Exhibition>
    {
        private readonly ExhibitionSeeder seeder;

        public ExhibitionEntityConfiguration()
        {
            this.seeder = new ExhibitionSeeder();
        }

        public void Configure(EntityTypeBuilder<Exhibition> builder)
        {
            builder
                .HasData(this.seeder.GeneratExhibitions());

            builder
                .Property(e => e.Start)
                .HasDefaultValue(DateTime.UtcNow);
            builder
                .Property(e => e.End)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}