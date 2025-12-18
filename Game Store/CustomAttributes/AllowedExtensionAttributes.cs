using System.ComponentModel.DataAnnotations;

namespace Game_Store.CustomAttributes
{
    public class AllowedExtensionAttributes : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;
        public AllowedExtensionAttributes(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions.Split(',');
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as Microsoft.AspNetCore.Http.IFormFile;
            if (file != null)
            {
                var extension = System.IO.Path.GetExtension(file.FileName);
                if (!_allowedExtensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult($"This file extension is not allowed. Allowed extensions are: {string.Join(", ", _allowedExtensions)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
