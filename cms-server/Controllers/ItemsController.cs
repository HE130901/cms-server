using cms_server.Data;
using cms_server.Models;
using Microsoft.AspNetCore.Mvc;



namespace cms_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return _context.Items.ToList();
        }
    }
}