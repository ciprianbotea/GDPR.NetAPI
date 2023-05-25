using GDPR.NetAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GDPR.NetAPI.Models
{
    public class GdprAgreement
    {
        [Key, Required, CodeValidation]
        public string identificationCode { get; set; } = string.Empty;
        [RequiredForNaturalPerson]
        public string firstName { get; set; } = string.Empty;
        [RequiredForNaturalPerson]
        public string lastName { get; set; } = string.Empty;
        [RequiredForLegalEntity]
        public string companyName { get; set; } = string.Empty;
        [Required]
        public string countyCode { get; set; } = string.Empty;
        [Required, PhoneValidation]
        public string mobilePhone { get; set;} = string.Empty;
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required, GdprAlwaysTrue]
        public Boolean gdprAgreement { get; set; }
        [Required]
        public Boolean marketingAgreement { get; set; }
        [Required, EmailOrMobileRequired]
        public Boolean emailCommunication { get; set; }
        [Required, EmailOrMobileRequired]
        public Boolean mobileCommunication { get; set; }
        [Required]
        public DateTime agreementDate { get; set; } = DateTime.UtcNow;
    }
}