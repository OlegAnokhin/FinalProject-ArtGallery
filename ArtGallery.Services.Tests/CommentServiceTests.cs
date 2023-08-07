namespace ArtGallery.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Interfaces;
    using ArtGallery.Data;
    using Web.ViewModels.Comment;
    using static DatabaseSeeder;

    public class CommentServiceTests
    {
        private DbContextOptions<ArtGalleryDbContext> dbOptions;
        private ArtGalleryDbContext dbContext;
        private ICommentService commentService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<ArtGalleryDbContext>()
                .UseInMemoryDatabase("ArtGalleryInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new ArtGalleryDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.commentService = new CommentService(this.dbContext);
        }

        [Test]
        public async Task AllCommentsWithAdminAsyncShouldReturnAllComments()
        {
            var newComment = new CommentViewModel
                {
                    CommentId = 1,
                    PictureId = 1,
                    Username = "user1",
                    Content = "Comment 1"
            };
            await this.commentService.AddCommentAsync(1, newComment);

            var newResult = await this.commentService.AllCommentsWithAdminAsync();
            var newCount = newResult.Count();

            Assert.That(newCount, Is.EqualTo(2));
        }

        [Test]
        public async Task AllCommentsAsyncShouldReturnAllComments()
        {
            var newComment = new CommentViewModel
            {
                CommentId = 2,
                PictureId = 2,
                Username = "user2",
                Content = "Comment 2"
            };
            await this.commentService.AddCommentAsync(2, newComment);

            var newResult = await this.commentService.AllCommentsAsync(2);
            var newCount = newResult.Count();

            Assert.That(newCount, Is.EqualTo(1));
        }

        //[Test]
        //public async Task DeleteCommentAsyncShouldDecreaseAllCommentsCount()
        //{
        //    var result = await this.commentService.AllCommentsWithAdminAsync();
        //    var count = result.Count();

        //    var newComment = new CommentViewModel
        //    {
        //        CommentId = 2,
        //        PictureId = 2,
        //        Username = "user2",
        //        Content = "Comment 2"
        //    };
        //    await this.commentService.AddCommentAsync(2, newComment);
        //    await this.commentService.DeleteCommentAsync(2);

        //    Assert.That(count, Is.EqualTo(0));
        //}

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            int existingCommenttId = 1;
            bool result = await this.commentService.ExistsByIdAsync(existingCommenttId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            int existingCommenttId = 666;
            bool result = await this.commentService.ExistsByIdAsync(existingCommenttId);

            Assert.IsFalse(result);
        }
    }
}