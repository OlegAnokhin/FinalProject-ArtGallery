namespace ArtGallery.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ArtEventParticipant
    {
        public string ParticipantId { get; set; } = null!;

        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; } = null!;

        public int ArtEventId { get; set; }

        [ForeignKey(nameof(ArtEventId))]
        public ArtEvent ArtEvent { get; set; } = null!;
    }
}