namespace ArtGallery.Data
{
    using System.Reflection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ArtGalleryDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Picture> Pictures { get; set; } = null!;

        public DbSet<Exhibition> Exhibitions { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<ArtEvent> ArtEvents { get; set; } = null!;

        public DbSet<ArtEventParticipant> ArtEventParticipants { get; set; } = null!;

        public DbSet<PictureComment> PicturesComment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(ArtGalleryDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}