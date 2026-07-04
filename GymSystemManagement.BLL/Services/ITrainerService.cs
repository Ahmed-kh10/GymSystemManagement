using GymSystemmanagement.DAL.Models;

public interface ITrainerService
{
    Task<List<Trainer>> GetAllAsync();
    Task<Trainer?> GetByIdAsync(int id);
    Task CreateAsync(TrainerCreateVM vm);
    Task UpdateAsync(int id, TrainerEditVM vm);
    Task DeleteAsync(int id);
}