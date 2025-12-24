using System.ComponentModel.DataAnnotations;

namespace WeddinGifts.Api.Dtos
{
    public class CreateCoupleDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime WeddingDate { get; set; }
    }
}
