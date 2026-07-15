using GymSystemmanagement.DAL.Models;
using GymSystemManagement.BLL.ViewModels.Memberships;

public class MembershipService : IMembershipService
{
    private readonly IUnitOfWork _unit;

    public MembershipService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<MembershipViewModel>> GetAllAsync()
    {
        var memberships = await _unit.MemberShips.GetAllAsync();

        return memberships.Select(x => new MembershipViewModel
        {
            Id = x.Id,
            MemberId = x.MemberId,
            MemberName = x.Member.Name,
            PlanName = x.Plan.Name,
            StartDate = x.CreatedAt,
            EndDate = x.EndDate,
            Status =  x.Status,
        }).ToList();
    }

    public async Task CreateAsync(CreateMembershipVM vm)
    {
        var member = await _unit.Members.GetByIdAsync(vm.MemberId);

        if (member == null)
            throw new Exception("Member Not Found");

        var plan = await _unit.Plans.GetByIdAsync(vm.PlanId);

        if (plan == null)
            throw new Exception("Plan Not Found");

        if (!plan.IsActive)
            throw new Exception("This Plan Is Not Active");

        var memberships = await _unit.MemberShips.GetAllAsync();

        bool hasActiveMembership = memberships.Any(x =>
            x.MemberId == vm.MemberId &&
            x.IsActive);

        if (hasActiveMembership)
            throw new Exception("Member Already Has Active Membership");

        MemberShip membership = new MemberShip
        {
            MemberId = vm.MemberId,
            PlanId = vm.PlanId,
            CreatedAt = DateTime.Now,
            EndDate = DateTime.Now.AddDays(plan.DurationDays)
        };

        await _unit.MemberShips.AddAsync(membership);

        await _unit.SaveAsync();
    }

    public async Task CancelAsync(int id)
    {
        var membership = await _unit.MemberShips.GetByIdAsync(id);

        if (membership == null)
            throw new Exception("Membership Not Found");

        if (!membership.IsActive)
            throw new Exception("Only Active Membership Can Be Cancelled");

        await _unit.MemberShips.DeleteAsync(id);

        await _unit.SaveAsync();
    }
}