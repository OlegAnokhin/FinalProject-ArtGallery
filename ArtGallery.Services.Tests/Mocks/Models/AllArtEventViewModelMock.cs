namespace ArtGallery.Services.Tests.Mocks.Models
{
    using Web.ViewModels.ArtEvent;

    public static class AllArtEventViewModelMock
    {
        public static AllArtEventViewModel Instance()
        {
            var allArtEventViewModel = new AllArtEventViewModel
            {
                Id = 1,
                Name = "Розовото дърво TEST",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
            };
            return allArtEventViewModel;
        }
    }
}