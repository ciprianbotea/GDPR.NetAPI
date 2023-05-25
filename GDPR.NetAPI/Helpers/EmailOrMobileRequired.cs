using GDPR.NetAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GDPR.NetAPI.Helpers
{
    public class EmailOrMobileRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var agreement = (GdprAgreement)validationContext.ObjectInstance;
            if (agreement.emailCommunication == true || agreement.mobileCommunication == true)
                return ValidationResult.Success;
            else
                return new ValidationResult("Either email or mobile communication is required!");

        }
    }
}