using GymSystemmanagement.DAL.Data;
using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

public class TrainerRepository : ITrainerRepository
{
    private readonly GymSystemManagementDbContext _context;

    public TrainerRepository(GymSystemManagementDbContext context)
    {
        _context = context;
    }

    public async Task<List<Trainer>> GetAllAsync()
    {
        return await _context.Trainers.ToListAsync();
    }

    public async Task<Trainer?> GetByIdAsync(int id)
    {
        return await _context.Trainers
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Trainer trainer)
    {
        await _context.Trainers.AddAsync(trainer);
    }

    public async Task DeleteAsync(int id)
    {
        var trainer = await GetByIdAsync(id);
        if (trainer != null)
            _context.Trainers.Remove(trainer);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}