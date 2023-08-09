namespace ArtGallery.Services.Tests.Mocks.Services
{
    using Moq;
    using Data.Interfaces;

    public static class ArtEventServiceMock
    {
        public static async Task<IArtEventService> Instance()
        {
            var artEventServiceMock = new Mock<IArtEventService>();

            return artEventServiceMock.Object;
        }
    }
}