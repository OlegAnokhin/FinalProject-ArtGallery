namespace ArtGallery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class OrderAPictureEntityConfiguration : IEntityTypeConfiguration<OrderAPicture>
    {
        public void Configure(EntityTypeBuilder<OrderAPicture> builder)
        {
            
        }
    }
}