using GymSystemmanagement.DAL.Data;
using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

public class MemberRepository : IMemberRepository
{
    private readonly GymSystemManagementDbContext _context;

    public MemberRepository(GymSystemManagementDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetAllAsync()
    {
        return await _context.Members.Include(x => x.Healthrecord).ToListAsync();
    }

    public async Task<Member?> GetByIdAsync(int id)
    {
        return await _context.Members
            .Include(x => x.Healthrecord)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Member member)
    {
        await _context.Members.AddAsync(member);
    }

    public async Task DeleteAsync(int id)
    {
        var member = await GetByIdAsync(id);
        if (member != null)
            _context.Members.Remove(member);
    }

    public async Task SaveAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }


}