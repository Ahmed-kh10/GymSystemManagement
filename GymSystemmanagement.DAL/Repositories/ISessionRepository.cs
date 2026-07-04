using GymSystemmanagement.DAL.Models;

public interface ISessionRepository
{
    Task<List<Session>> GetAllAsync();
    Task<Session?> GetByIdAsync(int id);
    Task AddAsync(Session session);
    Task DeleteAsync(int id);
}