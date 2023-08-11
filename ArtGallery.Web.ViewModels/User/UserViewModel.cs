namespace ArtGallery.Web.ViewModels.User
{
    public class UserViewModel
    {
        /// <summary>
        /// Идентификатор на потребителя
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// Електронна поща на потребителя
        /// </summary>
        public string Email { get; set; } = null!;
    }
}