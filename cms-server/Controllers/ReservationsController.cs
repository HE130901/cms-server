using Microsoft.AspNetCore.Mvc;
using cms_server.DTOs;
using cms_server.Services;
using System.Threading.Tasks;

namespace cms_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("create-reservation")]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new { message = "Invalid reservation data." });
            }

            try
            {
                await _reservationService.CreateReservationAsync(dto);
                return Ok(new { message = "Reservation created successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the reservation.", details = ex.Message });
            }
        }
    }
}
