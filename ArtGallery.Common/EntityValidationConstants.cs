namespace ArtGallery.Common
{
    public static class EntityValidationConstants
    {
        public static class Exhibition
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
            
            public const int PlaceMinLength = 2;
            public const int PlaceMaxLength = 50;
            
            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 250;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Picture
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int SizeMinLength = 2;
            public const int SizeMaxLength = 50;

            public const int MaterialMinLength = 2;
            public const int MaterialMaxLength = 50;

            public const int ImageAddressMinLength = 2;
            public const int ImageAddressMaxLength = 250;

            public const int ImageBaseMinLength = 2;
            public const int ImageBaseMaxLength = 250;

            public const int CategoryMinLength = 2;
            public const int CategoryMaxLength = 50;

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 250;

        }

        public static class ArtClass
        {

        }
    }
}
