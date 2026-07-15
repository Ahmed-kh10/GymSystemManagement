using GymSystemmanagement.DAL.Data;
using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

public class MembershipRepository : IMembershipRepository
{
    private readonly GymSystemManagementDbContext _context;

    public MembershipRepository(GymSystemManagementDbContext context)
    {
        _context = context;
    }

    public async Task<List<MemberShip>> GetAllAsync()
    {
        return await _context.MemberShips
            .Include(x => x.Member)
            .Include(x => x.Plan)
            .ToListAsync();
    }

    public async Task<MemberShip?> GetByIdAsync(int id)
    {
        return await _context.MemberShips
            .Include(x => x.Member)
            .Include(x => x.Plan)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(MemberShip membership)
    {
        await _context.MemberShips.AddAsync(membership);
    }

    public async Task DeleteAsync(int id)
    {
        var membership = await _context.MemberShips.FindAsync(id);

        if (membership != null)
            _context.MemberShips.Remove(membership);
    }
    public async Task<MemberShip?> GetActiveMembershipAsync(int memberId)
    {
        return await _context.MemberShips
            .Include(x => x.Plan)
            .FirstOrDefaultAsync(x =>
                x.MemberId == memberId &&
                x.EndDate > DateTime.Now &&
                x.Plan.IsActive);
    }
}