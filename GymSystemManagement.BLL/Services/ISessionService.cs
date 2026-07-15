using GymSystemmanagement.DAL.Models;

public interface ISessionService
{
    Task<List<SessionIndexVM>> GetAllAsync();
    Task<SessionDetailsVM?> GetByIdAsync(int id);
    Task CreateAsync(SessionCreateVM vm);
    Task UpdateAsync(int id, SessionEditVM vm);
    Task DeleteAsync(int id);
    Task<int> GetUpcomingCountAsync();
    Task<int> GetOngoingCountAsync();
    Task<int> GetCompletedCountAsync();
}