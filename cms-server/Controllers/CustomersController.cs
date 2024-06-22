using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cms_server.Models;
using cms_server.DTOs;

namespace cms_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CmsContext _context;

        public CustomersController(CmsContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /*// POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }*/

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAccount([FromBody] CreateNewCustomerAccountDTO customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest(new { message = "Invalid customer data" });
            }

            // Validate email and citizenID uniqueness
            if (await _context.Customers.AnyAsync(c => c.Email == customerDto.Email))
            {
                return BadRequest(new { message = "Email đã tồn tại" });
            }

            if (await _context.Customers.AnyAsync(c => c.CitizenId == customerDto.CitizenID))
            {
                return BadRequest(new { message = "CitizenID đã tồn tại" });
            }

            // Hash the password before saving (optional, for security)
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(customerDto.Password);

            var customer = new Customer
            {
                FullName = customerDto.FullName,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address,
                PasswordHash = passwordHash,
                CitizenId = customerDto.CitizenID,
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        public class CreateNewCustomerAccountDTO
        {
            public string FullName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string? Phone { get; set; }
            public string? Address { get; set; }
            public string Password { get; set; } = null!;
            public string? CitizenID { get; set; }
        }
    }
}
