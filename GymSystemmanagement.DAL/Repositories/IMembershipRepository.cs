using GymSystemmanagement.DAL.Models;

public interface IMembershipRepository
{
    Task<List<MemberShip>> GetAllAsync();

    Task<MemberShip?> GetByIdAsync(int id);

    Task<MemberShip?> GetActiveMembershipAsync(int memberId);

    Task AddAsync(MemberShip membership);

    Task DeleteAsync(int id);
}