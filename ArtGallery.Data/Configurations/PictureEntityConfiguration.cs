namespace ArtGallery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using Seeding;

    public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        private readonly PictureSeeder seeder;

        public PictureEntityConfiguration()
        {
            this.seeder = new PictureSeeder();
        }

        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasData(this.seeder.GeneratePictures());

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Pictures)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}