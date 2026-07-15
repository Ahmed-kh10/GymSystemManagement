using GymSystemmanagement.DAL.Data;
using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSystemManagement.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly GymSystemManagementDbContext _context;

        public BookingRepository(GymSystemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(x => x.Member)
                .Include(x => x.Session)
                .ThenInclude(x => x.Category)
                .Include(x => x.Session)
                .ThenInclude(x => x.Trainer)
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(x => x.Member)
                .Include(x => x.Session)
                .ThenInclude(x => x.Category)
                .Include(x => x.Session)
                .ThenInclude(x => x.Trainer)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Booking?> GetAsync(int memberId, int sessionId)
        {
            return await _context.Bookings
                .Include(x => x.Member)
                .Include(x => x.Session)
                .FirstOrDefaultAsync(x =>
                    x.MemberId == memberId &&
                    x.SessionId == sessionId);
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public Task DeleteAsync(Booking booking)
        {
            _context.Bookings.Remove(booking);
            return Task.CompletedTask;
        }
        public async Task<List<Booking>> GetBySessionAsync(int sessionId)
        {
            return await _context.Bookings
                .Include(x => x.Member)
                .Where(x => x.SessionId == sessionId)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetByMemberAsync(int memberId)
        {
            return await _context.Bookings
                .Include(x => x.Session)
                .ThenInclude(x => x.Category)
                .Include(x => x.Session)
                .ThenInclude(x => x.Trainer)
                .Where(x => x.MemberId == memberId)
                .ToListAsync();
        }
    }

}