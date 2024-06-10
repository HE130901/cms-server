namespace cms_server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        [HttpGet("customer")]
        [Authorize(Roles = "Customer")]
        public IActionResult GetForCustomer()
        {
            return Ok("This endpoint is accessible only by customers.");
        }

        [HttpGet("staff")]
        [Authorize(Roles = "Staff")]
        public IActionResult GetForStaff()
        {
            return Ok("This endpoint is accessible only by staff.");
        }

        [HttpGet("manager")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetForManager()
        {
            return Ok("This endpoint is accessible only by managers.");
        }
    }

}
