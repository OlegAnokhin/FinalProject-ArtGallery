namespace ArtGallery.Services.Tests.Mocks.Models
{
    using Web.ViewModels.Picture;

    public static class AddAndEditPictureViewModelMock
    {
        public static AddAndEditPictureViewModel Instance()
        {
            var addAndEditPictureViewModel = new AddAndEditPictureViewModel
            {
                Name = "Момиче с цвете",
                Size = "40 х 60",
                Material = "Акрил",
                ImageAddress = "\\lib\\images\\Girl1.jpg",
                ImageBase = "Платно",
                CategoryId = 2,
                Description = "Африканско момиче с цвете в косата"
            };
            return addAndEditPictureViewModel;
        }
    }
}