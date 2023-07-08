namespace ArtGallery.Web.ViewModels.Comment
{
    public class CommentFormModel
    {
        public CommentViewModel CurrentComment { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}