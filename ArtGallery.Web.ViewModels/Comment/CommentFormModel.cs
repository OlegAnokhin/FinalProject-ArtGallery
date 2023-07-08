namespace ArtGallery.Web.ViewModels.Comment
{
    public class CommentFormModel
    {
        public CommentFormModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }
        public CommentViewModel CurrentComment { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}