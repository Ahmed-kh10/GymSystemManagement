using GymSystemmanagement.DAL.Models;

namespace GymSystemManagement.Repositories
{
    public interface IPlanRepository
    {
        Task<List<Plan>> GetAllAsync();
        Task<Plan?> GetByIdAsync(int id);
        Task AddAsync(Plan plan);
        Task UpdateAsync(Plan plan);  
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}