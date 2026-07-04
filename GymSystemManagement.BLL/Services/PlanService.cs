using GymSystemmanagement.DAL.Models;
using GymSystemManagement.Services;

public class PlanService : IPlanService
{
    private readonly IUnitOfWork _unit;

    public PlanService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<Plan>> GetAllAsync()
    {
        return await _unit.Plans.GetAllAsync();
    }

    public async Task<Plan?> GetByIdAsync(int id)
    {
        return await _unit.Plans.GetByIdAsync(id);
    }

    public async Task AddAsync(Plan plan)
    {
        await _unit.Plans.AddAsync(plan);
        await _unit.SaveAsync();
    }

    public async Task UpdateAsync(Plan plan)
    {
        await _unit.Plans.UpdateAsync(plan);
        await _unit.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unit.Plans.DeleteAsync(id);
        await _unit.SaveAsync();
    }
}