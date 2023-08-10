namespace ArtGallery.Services.Tests.Mocks.Models
{
    using Web.ViewModels.Exhibition;

    public class ExhibitionFormModelMock
    {
        public static ExhibitionFormModel Instance()
        {
            var exhibitionFormModel = new ExhibitionFormModel
            {
                Name = "Изложба Африка",
                ImageUrl = "\\lib\\images\\ExhibitionAfrica.jpg",
                Start = DateTime.Parse("20-07-2023 10:00"),
                End = DateTime.Parse("30-07-2023 17:00"),
                Place = "Варна, Галерията на Петя",
                Description = "В тази изложба на тема Африка ще бъдат представени тематични картина на хора и животни."
            };
            return exhibitionFormModel;
        }
    }
}