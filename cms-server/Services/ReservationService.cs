using cms_server.DTOs;
using cms_server.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace cms_server.Services
{
    public interface IReservationService
    {
        Task CreateReservationAsync(CreateReservationDto request);
    }

    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateReservationAsync(CreateReservationDto request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Check if customer exists
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.CitizenId == request.BuyerCitizenId);
                if (customer == null)
                {
                    throw new Exception("Customer not found.");
                }

                // Create Recipient
                var recipient = new Recipient
                {
                    CitizenId = request.RecipientCitizenId,
                    FullName = request.RecipientFullname,
                    DateOfBirth = request.RecipientDOB,
                    NicheId = request.NicheId,
                    CustomerId = customer.CustomerId
                };
                _context.Recipients.Add(recipient);
                await _context.SaveChangesAsync();

                // Create NicheReservation
                var reservation = new NicheReservation
                {
                    CustomerId = customer.CustomerId,
                    RecipientId = recipient.RecipientId,
                    NicheId = request.NicheId,
                    ReservationDate = request.ReservationDate,
                    Status = request.Status,
                    ConfirmedBy = 2, // This should be replaced with actual staff ID
                    ConfirmationDate = request.ContractDate
                };
                _context.NicheReservations.Add(reservation);

                // Update Niche status
                var niche = await _context.Niches.FindAsync(request.NicheId);
                if (niche != null)
                {
                    niche.Status = "Booked";
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
