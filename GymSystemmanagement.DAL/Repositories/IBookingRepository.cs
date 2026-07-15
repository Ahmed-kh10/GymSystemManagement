using GymSystemmanagement.DAL.Models;

namespace GymSystemManagement.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();

        Task<Booking?> GetByIdAsync(int id);

        Task<Booking?> GetAsync(int memberId, int sessionId);

        Task<List<Booking>> GetBySessionAsync(int sessionId);

        Task<List<Booking>> GetByMemberAsync(int memberId);

        Task AddAsync(Booking booking);

        Task DeleteAsync(Booking booking);
    }
}