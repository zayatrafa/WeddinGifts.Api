namespace WeddinGifts.Api.Models
{
    public class CoupleUser
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int CoupleId { get; set; }
        public Couple Couple { get; set; } = null!;

        public CoupleRole Role { get; set; } = CoupleRole.Owner;

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
