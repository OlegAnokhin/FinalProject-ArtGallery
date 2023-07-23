namespace ArtGallery.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;

    class AdminAndUserSeeder
    {
        internal IdentityUser[] GenerateUsers()
        {
            ICollection<IdentityUser> users = new HashSet<IdentityUser>();
            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser currentUser;

            currentUser = new IdentityUser
            {
                Id = "d53a80c3-5fd9-4451-a381-f40d2f50ec08",
                UserName = "admin@ArtGallery.bg",
                NormalizedUserName = "ADMIN@ARTGALLERY.BG",
                Email = "admin@ArtGallery.bg",
                NormalizedEmail = "ADMIN@ARTGALLERY.BG",
            };
            currentUser.PasswordHash = hasher.HashPassword(currentUser, "admin123");
            users.Add(currentUser);

            currentUser = new IdentityUser
            {
                Id = "c1f40236-ee63-452f-8c56-18f952098074",
                UserName = "guest@ArtGallery.bg",
                NormalizedUserName = "GUEST@ARTGALLERY.BG",
                Email = "guest@ArtGallery.bg",
                NormalizedEmail = "GUEST@ARTGALLERY.BG",
            };
            currentUser.PasswordHash = hasher.HashPassword(currentUser, "guest123");
            users.Add(currentUser);

            return users.ToArray();
        }
    }
}