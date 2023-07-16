namespace ArtGallery.Data.Configurations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using Seeding;

    public class ArtEventEntityConfiguration : IEntityTypeConfiguration<ArtEvent>
    {
        private readonly ArtEventSeeder seeder;

        public ArtEventEntityConfiguration()
        {
            this.seeder = new ArtEventSeeder();
        }

        public void Configure(EntityTypeBuilder<ArtEvent> builder)
        {
            builder.HasData(this.seeder.GenerateArtEvents());

            builder
                .Property(e => e.Start)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}