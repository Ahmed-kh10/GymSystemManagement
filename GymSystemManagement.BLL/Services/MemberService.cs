using GymSystemmanagement.DAL.Models;

public class MemberService : IMemberService
{
    private readonly IUnitOfWork _unit;

    public MemberService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<Member>> GetAllAsync()
    {
        return await _unit.Members.GetAllAsync();
    }

    public async Task<Member?> GetByIdAsync(int id)
    {
        return await _unit.Members.GetByIdAsync(id);
    }

    public async Task CreateAsync(MemberCreateVM vm)
    {
        Member member = new Member
        {
            Name = vm.Name,
            Email = vm.Email,
            Phone = vm.Phone,
            Photo = vm.Photo,
            DateOfBirth = vm.DateOfBirth,
            Gender = vm.Gender,

            Address = new Address
            {
                City = vm.City,
                street = vm.Street,
                Building = vm.BuildingNumber
            },

            Healthrecord = new Healthrecord
            {
                Height = vm.Height,
                weight = vm.Weight,
                BloodType = vm.BloodType,
                Note = vm.Note
            }
        };

        await _unit.Members.AddAsync(member);
        await _unit.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unit.Members.DeleteAsync(id);
        await _unit.SaveAsync();
    }

    public async Task UpdateAsync(int id, MemberCreateVM vm)
    {
        var member = await _unit.Members.GetByIdAsync(id);

        if (member == null)
            throw new Exception("Member Not Found");

        member.Name = vm.Name;
        member.Email = vm.Email;
        member.Phone = vm.Phone;
        member.DateOfBirth = vm.DateOfBirth;
        member.Gender = vm.Gender;

        member.Address.City = vm.City;
        member.Address.street = vm.Street;
        member.Address.Building = vm.BuildingNumber;

        member.Healthrecord.Height = vm.Height;
        member.Healthrecord.weight = vm.Weight;
        member.Healthrecord.BloodType = vm.BloodType;
        member.Healthrecord.Note = vm.Note;

        await _unit.SaveAsync();
    }

    public async Task UpdateAsync(int id, MemberEditVM vm)
    {
        var member = await _unit.Members.GetByIdAsync(id);

        if (member == null)
            throw new Exception("Member Not Found");

        member.Email = vm.Email;
        member.Phone = vm.Phone;

        member.Address.City = vm.City;
        member.Address.street = vm.Street;
        member.Address.Building = vm.BuildingNumber;

        await _unit.SaveAsync();
    }
}