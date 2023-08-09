namespace ArtGallery.Services.Tests.Mocks.Models
{
    using Web.ViewModels.ArtEvent;

    public static class ArtEventFormModelMock
    {
        public static ArtEventFormModel Instance()
        {
            var artEventFormModel = new ArtEventFormModel
            {
                Name = "Розовото дърво TEST",
                ImageAddress = "\\lib\\images\\ArtEventPinkTree.jpg",
                Start = DateTime.Parse("26-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "Обучение тип Арт-клас, в него заедно ще нарисуваме невероятна картина, а аз ще пи покажа нужни техники и ще ви напътствам през цялото време.",
            };
            return artEventFormModel;
        }
    }
}