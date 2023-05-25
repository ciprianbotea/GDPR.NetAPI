using GDPR.NetAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GDPR.NetAPI.Helpers
{
    public class RequiredForNaturalPerson : ValidationAttribute
    {

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var agreement = (GdprAgreement)validationContext.ObjectInstance;
            if (agreement.identificationCode.ToLower().Contains("cnp"))
                if (agreement.firstName == null || agreement.firstName.Length < 3
                    || agreement.lastName == null || agreement.lastName.Length < 3)
                    return new ValidationResult("Both first and last name are required!");
                return ValidationResult.Success;

        }
    }
}