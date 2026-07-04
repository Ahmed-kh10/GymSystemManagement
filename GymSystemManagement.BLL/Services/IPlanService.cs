using GymSystemmanagement.DAL.Models;

namespace GymSystemManagement.Services
{
    public interface IPlanService
    {
        Task<List<Plan>> GetAllAsync();
        Task<Plan?> GetByIdAsync(int id);
        Task AddAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        Task DeleteAsync(int id);
    }
}