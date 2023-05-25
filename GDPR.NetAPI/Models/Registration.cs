using System.ComponentModel.DataAnnotations;

namespace GDPR.NetAPI.Models
{
    public class Registration
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}