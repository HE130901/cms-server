using cms_server.DTOs;
using cms_server.Services;
using Microsoft.AspNetCore.Mvc;
namespace cms_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientsController : ControllerBase
    {
        private readonly IRecipientService _recipientService;

        public RecipientsController(IRecipientService recipientService)
        {
            _recipientService = recipientService;
        }

        [HttpGet("check-citizen-id")]
        public async Task<ActionResult<CheckCitizenIdResponse>> CheckCitizenId([FromQuery] CheckCitizenIdRequest request)
        {
            var exists = await _recipientService.CheckCitizenIdExistsAsync(request.CitizenId);
            return Ok(new CheckCitizenIdResponse { Exists = exists });
        }
    }
}
