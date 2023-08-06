// ReSharper disable VirtualMemberCallInConstructor
namespace ArtGallery.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Reflection;

    public class ArtGalleryDbContext : IdentityDbContext
    {
    public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options)
            : base(options)
        {
            if (!this.Database.IsRelational())
            {
                this.Database.EnsureCreated();
            }
        }

        public DbSet<Picture> Pictures { get; set; } = null!;

        public DbSet<Exhibition> Exhibitions { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<ArtEvent> ArtEvents { get; set; } = null!;

        public DbSet<ArtEventParticipant> ArtEventParticipants { get; set; } = null!;

        public DbSet<OrderAPicture> OrdersAPictures { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(ArtGalleryDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}