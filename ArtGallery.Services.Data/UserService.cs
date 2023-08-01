namespace ArtGallery.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtGallery.Data;
    using Interfaces;
    using Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly ArtGalleryDbContext dbContext;

        public UserService(ArtGalleryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            var allUsers = await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                }).ToListAsync();

            return allUsers;
        }
    }
}