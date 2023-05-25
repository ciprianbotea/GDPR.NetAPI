using GDPR.NetAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GDPR.NetAPI.Helpers
{
    public class CodeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var agreement = (GdprAgreement)validationContext.ObjectInstance;
            string pattern1 = @"CNP[0-9]{4}";
            string pattern2 = @"CUI[0-9]{4}";
            bool isValid = Regex.IsMatch(agreement.identificationCode, pattern1) || Regex.IsMatch(agreement.identificationCode, pattern2);
            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult("The identification code is not valid.");

        }
    }
}