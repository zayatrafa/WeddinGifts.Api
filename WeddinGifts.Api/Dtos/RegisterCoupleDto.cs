using System.ComponentModel.DataAnnotations;

namespace WeddinGifts.Api.Dtos
{
    public class RegisterCoupleDto
    {
        // User data
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        // Couple data
        [Required]
        public string CoupleName { get; set; } = string.Empty;

        [Required]
        public DateTime WeddingDate { get; set; }
    }
}
