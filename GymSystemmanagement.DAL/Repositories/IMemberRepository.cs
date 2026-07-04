using GymSystemmanagement.DAL.Models;

public interface IMemberRepository
{
    Task<List<Member>> GetAllAsync();
    Task<Member?> GetByIdAsync(int id);
    Task AddAsync(Member member);
    Task DeleteAsync(int id);
}