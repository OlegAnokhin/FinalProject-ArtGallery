namespace ArtGallery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ExhibitionEntityConfiguration : IEntityTypeConfiguration<Exhibition>
    {
        public void Configure(EntityTypeBuilder<Exhibition> builder)
        {
            builder
                .Property(e => e.Start)
                .HasDefaultValue(DateTime.UtcNow);
            builder
                .Property(e => e.End)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}