using System.ComponentModel.DataAnnotations;

namespace WeddinGifts.Api.Dtos
{
    public class CreateGiftDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
