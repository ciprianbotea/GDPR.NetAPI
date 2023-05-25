using GDPR.NetAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GDPR.NetAPI.Helpers
{
    public class RequiredForLegalEntity : ValidationAttribute
    {

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var agreement = (GdprAgreement)validationContext.ObjectInstance;
            if (agreement.identificationCode.ToLower().Contains("cui"))
                if(agreement.companyName == null || agreement.companyName.Length<3)
                    return new ValidationResult("Company name is required!");
                return ValidationResult.Success;

        }
    }
}