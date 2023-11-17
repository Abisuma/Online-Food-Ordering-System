using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class WebsiteUrlValidationAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid URL.";

        public WebsiteUrlValidationAttribute()
            : base(DefaultErrorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string url = value.ToString();

                // Your custom regular expression for URL validation
                string pattern = @"^(https?://)?(www\.)?([a-zA-Z0-9-]+\.){1,}[a-zA-Z]{2,6}(/\S*)?$";

                if (!Regex.IsMatch(url, pattern))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
