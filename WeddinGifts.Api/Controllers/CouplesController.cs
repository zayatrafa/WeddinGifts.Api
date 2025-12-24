using Microsoft.AspNetCore.Mvc;
using WeddinGifts.Api.Data;
using WeddinGifts.Api.Dtos;
using WeddinGifts.Api.Models;

namespace WeddinGifts.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouplesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CouplesController(AppDbContext context)
        {
            _context = context;
        }

        // POST /api/couples
        [HttpPost]
        public IActionResult Create(CreateCoupleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var couple = new Couple
            {
                Name = dto.Name,
                WeddingDate = dto.WeddingDate
            };

            _context.Couples.Add(couple);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = couple.Id }, couple);
        }

        // GET /api/couples/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var couple = _context.Couples.Find(id);

            if (couple == null)
                return NotFound();

            return Ok(couple);
        }
    }
}
