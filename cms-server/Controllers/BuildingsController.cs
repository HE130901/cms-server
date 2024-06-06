using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cms_server.Data;

namespace cms_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BuildingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildings()
        {
            var buildings = await _context.Buildings.ToListAsync();
            return Ok(buildings);
        }

        [HttpGet("{buildingId}/floors")]
        public async Task<IActionResult> GetFloors(int buildingId)
        {
            var floors = await _context.Floors.Where(f => f.BuildingId == buildingId).ToListAsync();
            return Ok(floors);
        }

        [HttpGet("{buildingId}/floors/{floorId}/sections")]
        public async Task<IActionResult> GetSections(int buildingId, int floorId)
        {
            var sections = await _context.Sections.Where(s => s.FloorId == floorId).ToListAsync();
            return Ok(sections);
        }

        [HttpGet("{buildingId}/floors/{floorId}/sections/{sectionId}/niches")]
        public async Task<IActionResult> GetNiches(int buildingId, int floorId, int sectionId)
        {
            var niches = await _context.Niches.Where(n => n.SectionId == sectionId).ToListAsync();
            return Ok(niches);
        }
    }
}
