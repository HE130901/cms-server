using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using cms_server.DTOs;
using cms_server.Models;
using System.Text;

namespace CMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CmsContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(CmsContext context, IConfiguration configuration)
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
                var token = GenerateJwtToken(customer.CustomerId.ToString(), customer.AccountStatus, customer.Phone, customer.Address);
                return Ok(new
                {
                    Token = token,
                    Role = customer.AccountStatus
                });
            }

            var staff = _context.Staff.SingleOrDefault(s => s.Email == loginDto.Email);
            if (staff != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, staff.PasswordHash))
            {
                var token = GenerateJwtToken(staff.StaffId.ToString(), staff.Role, staff.Phone, staff.Email);
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
                CitizenId = registerDto.CitizenId,
                AccountStatus = "Guest"
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok("Registration successful.");
        }

        [HttpGet("get-current-user")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
            {
                return Unauthorized("Invalid token.");
            }

            if (role == "Customer" || role == "Guest")
            {
                if (int.TryParse(userId, out int parsedUserId))
                {
                    var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == parsedUserId);
                    if (customer == null)
                    {
                        return NotFound("Customer not found.");
                    }

                    return Ok(new
                    {
                        customerId = customer.CustomerId,
                        fullName = customer.FullName,
                        citizenId = customer.CitizenId,
                        role = customer.AccountStatus,
                        email = customer.Email,
                        phone = customer.Phone,
                        address = customer.Address
                    });
                }
            }
            else if (role == "Staff" || role == "Manager")
            {
                if (int.TryParse(userId, out int parsedUserId))
                {
                    var staff = _context.Staff.SingleOrDefault(s => s.StaffId == parsedUserId);
                    if (staff == null)
                    {
                        return NotFound("Staff not found.");
                    }

                    return Ok(new
                    {
                        staffId = staff.StaffId,
                        fullName = staff.FullName,
                        role = staff.Role,
                        email = staff.Email,
                        phone = staff.Phone
                    });
                }
            }

            return Unauthorized("Invalid user role.");
        }

        private string GenerateJwtToken(string userId, string role, string phone, string address)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, role),
                new Claim("Phone", phone),
                new Claim("Address", address)
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
