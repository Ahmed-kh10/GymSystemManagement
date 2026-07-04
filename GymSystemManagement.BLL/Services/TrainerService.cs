using GymSystemmanagement.DAL.Models;

public class TrainerService : ITrainerService
{
    private readonly IUnitOfWork _unit;

    public TrainerService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<Trainer>> GetAllAsync()
    {
        return await _unit.Trainers.GetAllAsync();
    }

    public async Task<Trainer?> GetByIdAsync(int id)
    {
        return await _unit.Trainers.GetByIdAsync(id);
    }

    public async Task CreateAsync(TrainerCreateVM vm)
    {
        var trainer = new Trainer
        {
            Name = vm.Name,
            Email = vm.Email,
            Phone = vm.Phone,
            DateOfBirth = vm.DateOfBirth,
            Gender = vm.Gender,
            Specialty = vm.Specialty,

            Address = new Address
            {
                City = vm.City,
                street = vm.Street,
                Building = vm.BuildingNumber
            },

            CreatedAt = DateTime.Now
        };

        await _unit.Trainers.AddAsync(trainer);
        await _unit.SaveAsync();
    }

    public async Task UpdateAsync(int id, TrainerEditVM vm)
    {
        var trainer = await _unit.Trainers.GetByIdAsync(id);

        if (trainer == null)
            throw new Exception("Trainer Not Found");

        trainer.Email = vm.Email;
        trainer.Phone = vm.Phone;
        trainer.Specialty = vm.Specialty;

        trainer.Address.City = vm.City;
        trainer.Address.street = vm.Street;
        trainer.Address.Building = vm.BuildingNumber;

        trainer.UpdatedAt = DateTime.Now;

        await _unit.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unit.Trainers.DeleteAsync(id);
        await _unit.SaveAsync();
    }
}