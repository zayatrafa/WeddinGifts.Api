using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WeddinGifts.Api.Data;
using WeddinGifts.Api.Dtos;
using WeddinGifts.Api.Models;


namespace WeddinGifts.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // POST /api/auth/login
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var passwordHash = HashPassword(dto.Password);

            if (user.PasswordHash != passwordHash)
                return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.Name)
    };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // POST /api/auth/register
        [HttpPost("register")]
        public IActionResult Register(RegisterCoupleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Check if email already exists
            if (_context.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Email already registered");

            // 2. Create User
            var user = new User
            {
                Name = dto.UserName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            // 3. Create Couple
            var couple = new Couple
            {
                Name = dto.CoupleName,
                WeddingDate = dto.WeddingDate
            };

            _context.Couples.Add(couple);
            _context.SaveChanges();

            // 4. Link User ↔ Couple as Owner
            var coupleUser = new CoupleUser
            {
                UserId = user.Id,
                CoupleId = couple.Id,
                Role = CoupleRole.Owner
            };

            _context.CoupleUsers.Add(coupleUser);
            _context.SaveChanges();

            return Ok(new
            {
                message = "User and couple created successfully",
                userId = user.Id,
                coupleId = couple.Id
            });
        }

        // Temporary password hashing (will improve later)
        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
