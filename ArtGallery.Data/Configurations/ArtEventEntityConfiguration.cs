namespace ArtGallery.Data.Configurations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ArtEventEntityConfiguration : IEntityTypeConfiguration<ArtEvent>
    {
        public void Configure(EntityTypeBuilder<ArtEvent> builder)
        {
            builder
                .Property(e => e.Start)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}