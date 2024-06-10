using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cms_server.Models;

namespace cms_server.Services
{
    public interface IRecipientService
    {
        Task<bool> CheckCitizenIdExistsAsync(string citizenId);
    }

    public class RecipientService : IRecipientService
    {
        private readonly ApplicationDbContext _context;

        public RecipientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckCitizenIdExistsAsync(string citizenId)
        {
            return await _context.Recipients.AnyAsync(r => r.CitizenId == citizenId);
        }
    }
}
