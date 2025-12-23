using Microsoft.AspNetCore.Mvc;
using WeddinGifts.Api.Data;
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



        // POST /api/gifts
        [HttpPost]
        public IActionResult Create(Gift gift)
        {
            _logger.LogInformation(">>> [Método POST do Controller]");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation(">>> Salvando gift: {Name}", gift.Name);

            _context.Gifts.Add(gift);
            _context.SaveChanges();

            _logger.LogInformation(">>> Gift salvo com ID {Id}", gift.Id);

            return CreatedAtAction(nameof(GetAll), gift);
        }


    }
}
