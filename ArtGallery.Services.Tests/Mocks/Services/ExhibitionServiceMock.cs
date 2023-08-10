namespace ArtGallery.Services.Tests.Mocks.Services
{
    using Moq;
    using Data.Interfaces;

    public static class ExhibitionServiceMock
    {
        public static async Task<IExhibitionService> Instance()
        {
            var exhibitionServiceMock = new Mock<IExhibitionService>();

            return exhibitionServiceMock.Object;
        }
    }
}