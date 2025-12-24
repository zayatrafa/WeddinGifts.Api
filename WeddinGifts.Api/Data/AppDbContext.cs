using Microsoft.EntityFrameworkCore;
using WeddinGifts.Api.Models;

namespace WeddinGifts.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Couple> Couples => Set<Couple>();
        public DbSet<CoupleUser> CoupleUsers => Set<CoupleUser>();
        public DbSet<Gift> Gifts => Set<Gift>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite primary key for the join table
            modelBuilder.Entity<CoupleUser>()
                .HasKey(cu => new { cu.UserId, cu.CoupleId });

            // User ↔ CoupleUser (1:N)
            modelBuilder.Entity<CoupleUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.CoupleUsers)
                .HasForeignKey(cu => cu.UserId);

            // Couple ↔ CoupleUser (1:N)
            modelBuilder.Entity<CoupleUser>()
                .HasOne(cu => cu.Couple)
                .WithMany(c => c.CoupleUsers)
                .HasForeignKey(cu => cu.CoupleId);

            // Store enum as int (default, but explicit is better)
            modelBuilder.Entity<CoupleUser>()
                .Property(cu => cu.Role)
                .HasConversion<int>();
        }
    }
}
