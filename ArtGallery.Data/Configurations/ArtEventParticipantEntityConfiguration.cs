namespace ArtGallery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ArtEventParticipantEntityConfiguration : IEntityTypeConfiguration<ArtEventParticipant>
    {
        public void Configure(EntityTypeBuilder<ArtEventParticipant> builder)
        {
            builder
                .HasKey(pc => new { pc.ParticipantId, pc.ArtEventId });
            builder
                .HasOne(e => e.ArtEvent)
                .WithMany(p => p.ArtEventParticipants)
                .HasForeignKey(e => e.ArtEventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}