using GDPR.NetAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GDPR.NetAPI.Helpers
{
    public class PhoneValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var agreement = (GdprAgreement)validationContext.ObjectInstance;
            string pattern = @"555[0-9]{6}";
            bool isValid = Regex.IsMatch(agreement.mobilePhone, pattern);
            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult("The mobile phone field is not a valid mobile phone number.");

        }
    }
}