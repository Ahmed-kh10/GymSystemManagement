using GymSystemManagement.BLL.ViewModels.Memberships;

public interface IMembershipService
{
    Task<List<MembershipViewModel>> GetAllAsync();

    Task CreateAsync(CreateMembershipVM vm);

    Task CancelAsync(int id);
}