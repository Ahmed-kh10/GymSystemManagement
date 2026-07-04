using GymSystemmanagement.DAL.Models;

public interface ITrainerRepository
{
    Task<List<Trainer>> GetAllAsync();
    Task<Trainer?> GetByIdAsync(int id);
    Task AddAsync(Trainer trainer);
    Task DeleteAsync(int id);
    Task SaveAsync();
}