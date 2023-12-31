﻿namespace ArtGallery.Common
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
            
            public const int ImageUrlMinLength = 2;
            public const int ImageUrlMaxLength = 2048;
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
            public const int ImageAddressMaxLength = 2048;

            public const int ImageBaseMinLength = 2;
            public const int ImageBaseMaxLength = 250;

            public const int CategoryMinLength = 2;
            public const int CategoryMaxLength = 50;

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 250;
        }

        public static class Comment
        {
            public const int UsernameMinLength = 2;
            public const int UsernameMaxLength = 50;
            
            public const int CommentMinLength = 2;
            public const int CommentMaxLength = 250;
        }
        
        public static class ArtClass
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int ImageAddressMinLength = 2;
            public const int ImageAddressMaxLength = 2048;

            public const int PlaceMinLength = 2;
            public const int PlaceMaxLength = 50;

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 250;
        }

        public static class OrderAPicture
        {
            public const int FullnameMinLength = 5;
            public const int FullnameMaxLength = 50;

            public const int SizeMinLength = 2;
            public const int SizeMaxLength = 50;
            
            public const int PhoneNumberMinLength = 2;
            public const int PhoneNumberMaxLength = 50;

            public const int MaterialMinLength = 2;
            public const int MaterialMaxLength = 50;

            public const int ImageBaseMinLength = 2;
            public const int ImageBaseMaxLength = 250;

            public const int ImageMaxSize = (10 * 1024 * 1024);

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 250;
        }
    }
}
