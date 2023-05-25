using GDPR.NetAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GDPR.NetAPI.Helpers
{
    public class GdprAlwaysTrue : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var agreement = (GdprAgreement)validationContext.ObjectInstance;
            if (agreement.gdprAgreement == true)
                return ValidationResult.Success;
            else
                return new ValidationResult("GDPR agreement is mandatory.");

        }
    }
}