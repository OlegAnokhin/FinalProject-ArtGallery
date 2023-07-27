namespace ArtGallery.Common
{
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class MaxByteArraySizeAttribute : ValidationAttribute
    {
        private readonly int maxSizeInBytes;

        public MaxByteArraySizeAttribute(int maxSizeInBytes)
        {
            this.maxSizeInBytes = maxSizeInBytes;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is byte[] byteArray && byteArray.Length > maxSizeInBytes)
            {
                return new ValidationResult($"Максималния размер на изображението е {maxSizeInBytes} байта.");
            }

            return ValidationResult.Success;
        }
    }
}