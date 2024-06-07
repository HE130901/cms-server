using cms_server.Data;
using cms_server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace cms_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitBooking([FromBody] Booking formData)
        {
            if (ModelState.IsValid)
            {
                var niche = await _context.Niches.FirstOrDefaultAsync(n => n.Id == formData.NicheId);
                if (niche == null)
                {
                    return NotFound("Niche not found");
                }

                // Update the status and BookedUntil date
                niche.Status = "booked";
                niche.BookedUntil = DateTime.UtcNow.AddDays(7);

                // Save the booking information if necessary
                var booking = new Booking
                {
                    Name = formData.Name,
                    Email = formData.Email,
                    Phone = formData.Phone,
                    CCCD = formData.CCCD,
                    BuildingId = formData.BuildingId,
                    FloorId = formData.FloorId,
                    SectionId = formData.SectionId,
                    NicheId = formData.NicheId,
                    BookedAt = DateTime.UtcNow
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return Ok(niche); // Return the updated niche
            }

            return BadRequest(ModelState);
        }
    }
}
