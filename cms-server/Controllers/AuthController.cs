using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using cms_server.DTOs;
using cms_server.Models;

namespace CMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Email == loginDto.Email);
            if (customer != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, customer.PasswordHash))
            {
                var token = GenerateJwtToken(customer, "Customer");
                return Ok(new
                {
                    Token = token,
                    Role = "Customer"
                });
            }

            var staff = _context.Staff.SingleOrDefault(s => s.Email == loginDto.Email);
            if (staff != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, staff.PasswordHash))
            {
                var token = GenerateJwtToken(new Customer { CustomerId = staff.StaffId }, staff.Role);
                return Ok(new
                {
                    Token = token,
                    Role = staff.Role
                });
            }

            return Unauthorized("Invalid credentials.");
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (_context.Customers.Any(c => c.Email == registerDto.Email))
                return BadRequest("Email already in use.");

            var customer = new Customer
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                Address = registerDto.Address,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                CitizenId = registerDto.CitizenId
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok("Registration successful.");
        }

        [HttpGet("get-cusId")]
        public IActionResult GetCustomerId()
        {
            var customerId = GetCustomerClaim(ClaimTypes.NameIdentifier);
            return Ok(customerId);
        }

        [HttpGet("get-cusFullname")]
        public IActionResult GetCustomerFullname()
        {
            var customerId = GetCustomerClaim(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Find(int.Parse(customerId));
            return Ok(customer?.FullName);
        }

        [HttpGet("get-cusEmail")]
        public IActionResult GetCustomerEmail()
        {
            var customerId = GetCustomerClaim(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Find(int.Parse(customerId));
            return Ok(customer?.Email);
        }

        [HttpGet("get-cusPhone")]
        public IActionResult GetCustomerPhone()
        {
            var customerId = GetCustomerClaim(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Find(int.Parse(customerId));
            return Ok(customer?.Phone);
        }

        [HttpGet("get-cusAddress")]
        public IActionResult GetCustomerAddress()
        {
            var customerId = GetCustomerClaim(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Find(int.Parse(customerId));
            return Ok(customer?.Address);
        }

        [HttpGet("get-cusCitizenId")]
        public IActionResult GetCustomerCitizenId()
        {
            var customerId = GetCustomerClaim(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Find(int.Parse(customerId));
            return Ok(customer?.CitizenId);
        }

        private string GetCustomerClaim(string claimType)
        {
            var claim = HttpContext.User.Identity as ClaimsIdentity;
            var claimValue = claim?.FindFirst(claimType)?.Value;
            return claimValue;
        }

        private string GenerateJwtToken(Customer customer, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customer.CustomerId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
