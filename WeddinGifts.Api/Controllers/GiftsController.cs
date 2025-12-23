using Microsoft.AspNetCore.Mvc;
using WeddinGifts.Api.Data;
using WeddinGifts.Api.Dtos;
using WeddinGifts.Api.Models;

namespace WeddinGifts.Api.Controllers
{
    // Defines the base route for this controller.
    // The [controller] token is replaced by the controller name
    // without the "Controller" suffix (e.g. GiftsController -> gifts).
    [Route("api/[controller]")]

    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GiftsController> _logger;

        public GiftsController(AppDbContext context, ILogger<GiftsController> logger)
        {
            _context = context;
            _logger = logger;

            _logger.LogInformation(">>> [Construtor do GiftsController]");
            _logger.LogInformation(">>> GiftsController instanciado");
        }

        // GET /api/gifts
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation(">>> [Método GET do Controller]");

            var gifts = _context.Gifts.ToList();

            _logger.LogInformation(">>> HTTP Method visto pelo controller: {Method}", HttpContext.Request.Method);

            _logger.LogInformation(">>> {Count} gifts encontrados no banco", gifts.Count);

            return Ok(gifts);
        }

        // GET /api/gifts/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation(">>> GET /api/gifts/{id}", id);

            var gift = _context.Gifts.Find(id);

            if (gift == null)
                return NotFound();

            return Ok(gift);
        }

        // POST /api/gifts
        [HttpPost]
        public IActionResult Create(CreateGiftDto dto)
        {
            _logger.LogInformation(">>> POST /api/gifts iniciado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gift = new Gift
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                IsActive = true
            };

            _context.Gifts.Add(gift);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = gift.Id }, gift);
        }
    }
}