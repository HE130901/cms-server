using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cms_server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly CmsbdContext _context;

        public BuildingsController(CmsbdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        [HttpGet("{buildingId}/floors")]
        public async Task<ActionResult<IEnumerable<Floor>>> GetFloors(int buildingId)
        {
            return await _context.Floors.Where(f => f.BuildingId == buildingId).ToListAsync();
        }

        [HttpGet("{buildingId}/floors/{floorId}/areas")]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas(int buildingId, int floorId)
        {
            return await _context.Areas.Where(a => a.FloorId == floorId && a.Floor.BuildingId == buildingId).ToListAsync();
        }

        [HttpGet("{buildingId}/floors/{floorId}/areas/{areaId}/niches")]
        public async Task<ActionResult<IEnumerable<Niche>>> GetNiches(int buildingId, int floorId, int areaId)
        {
            return await _context.Niches.Where(n => n.AreaId == areaId && n.Area.FloorId == floorId && n.Area.Floor.BuildingId == buildingId).ToListAsync();
        }
    }
}
