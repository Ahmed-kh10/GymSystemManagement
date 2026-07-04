using GymSystemmanagement.DAL.Models;

public interface IMemberService
{
    Task<List<Member>> GetAllAsync();
    Task<Member?> GetByIdAsync(int id);
    Task CreateAsync(MemberCreateVM vm);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, MemberCreateVM vm);
    Task UpdateAsync(int id, MemberEditVM vm);
}