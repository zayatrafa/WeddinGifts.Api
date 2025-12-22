using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddinGifts.Api.Models
{
    public class Gift
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }


        [Range(0.01, double.MaxValue)]

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
