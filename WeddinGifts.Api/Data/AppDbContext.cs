using Microsoft.EntityFrameworkCore;
using WeddinGifts.Api.Models;


namespace WeddinGifts.Api.Data
{
    public class AppDbContext : DbContext
    {
        private readonly ILogger<AppDbContext> _logger;

        public AppDbContext(DbContextOptions<AppDbContext> options, ILogger<AppDbContext> logger) : base(options)
        {
            _logger = logger;
            _logger.LogInformation(">>> [Construtor da AppDbContext para ser passada como parâmetro para o construtor do GiftsController]");
            _logger.LogInformation(">>> AppDbContext criado com sucesso");
        }

        public DbSet<Gift> Gifts { get; set; }
    }

}
