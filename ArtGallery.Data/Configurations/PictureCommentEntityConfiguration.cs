namespace ArtGallery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class PictureCommentEntityConfiguration : IEntityTypeConfiguration<PictureComment>
    {
        public void Configure(EntityTypeBuilder<PictureComment> builder)
        {
            builder
                .HasKey(pc => new { pc.PictureId, pc.CommentId });
        }
    }
}