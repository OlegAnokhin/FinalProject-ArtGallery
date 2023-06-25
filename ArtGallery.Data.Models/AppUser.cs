namespace ArtGallery.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}