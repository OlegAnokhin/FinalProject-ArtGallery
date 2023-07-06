namespace ArtGallery.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Pictures)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);

        }
    }
}
