namespace ArtGallery.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Seeding;

    public class UsersEntityConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        private readonly AdminAndUserSeeder seeder;

        public UsersEntityConfiguration()
        {
            this.seeder = new AdminAndUserSeeder();
        }

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder
                .HasData(this.seeder.GenerateUsers());
        }
    }
}