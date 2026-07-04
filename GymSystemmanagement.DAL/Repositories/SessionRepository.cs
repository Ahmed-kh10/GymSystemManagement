using GymSystemmanagement.DAL.Data;
using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

public class SessionRepository : ISessionRepository
{
    private readonly GymSystemManagementDbContext _context;

    public SessionRepository(GymSystemManagementDbContext context)
    {
        _context = context;
    }

    public async Task<List<Session>> GetAllAsync()
    {
        return await _context.Sessions
            .Include(x => x.Trainer)
            .Include(x => x.Category)
            .Include(x => x.SessionMembers)
            .ToListAsync();
    }

    public async Task<Session?> GetByIdAsync(int id)
    {
        return await _context.Sessions
            .Include(x => x.Trainer)
            .Include(x => x.Category)
            .Include(x => x.SessionMembers)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Session session)
    {
        await _context.Sessions.AddAsync(session);
    }

    public async Task DeleteAsync(int id)
    {
        var session = await GetByIdAsync(id);

        if (session != null)
            _context.Sessions.Remove(session);
    }
}