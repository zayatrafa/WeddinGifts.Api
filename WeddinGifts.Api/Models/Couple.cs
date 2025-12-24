using System.ComponentModel.DataAnnotations;

namespace WeddinGifts.Api.Models
{
    public class Couple
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        // Ex: "Rafael & Lígia"

        public DateTime WeddingDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<CoupleUser> CoupleUsers { get; set; } = new List<CoupleUser>();

        public ICollection<Gift> Gifts { get; set; } = new List<Gift>();
    }
}
