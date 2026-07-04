using GymSystemmanagement.DAL.Data;
using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSystemManagement.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymSystemManagementDbContext _context;

        public PlanRepository(GymSystemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<Plan>> GetAllAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<Plan?> GetByIdAsync(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task AddAsync(Plan plan)
        {
            await _context.Plans.AddAsync(plan);
        }

        public async Task UpdateAsync(Plan plan)
        {
            _context.Plans.Update(plan);
        }

        public async Task DeleteAsync(int id)
        {
            var plan = await _context.Plans.FindAsync(id);

            if (plan != null)
                _context.Plans.Remove(plan);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}