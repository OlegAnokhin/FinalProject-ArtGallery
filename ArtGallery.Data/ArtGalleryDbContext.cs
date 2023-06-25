namespace ArtGallery.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using ArtGallery.Data.Models;

    public class ArtGalleryDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options)
            : base(options)
        {
        }
    }
}