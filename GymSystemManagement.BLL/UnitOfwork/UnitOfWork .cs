using GymSystemmanagement.DAL.Data;
using GymSystemmanagement.DAL.Models;
using GymSystemManagement.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly GymSystemManagementDbContext _context;

    public IMemberRepository Members { get; }

    public ITrainerRepository Trainers { get; }

    public IPlanRepository Plans { get; }

    public ISessionRepository Sessions { get; }

    public ICategoryRepository Categories { get; }

    public IMembershipRepository MemberShips { get; }

    public IBookingRepository Bookings { get; }


    public UnitOfWork(
     GymSystemManagementDbContext context,
     IMemberRepository members,
     ITrainerRepository trainers,
     IPlanRepository plans,
     ISessionRepository sessions,
     ICategoryRepository categories,
     IMembershipRepository memberShips,
     IBookingRepository bookings)
    {
        _context = context;

        Members = members;
        Trainers = trainers;
        Plans = plans;
        Sessions = sessions;
        Categories = categories;
        MemberShips = memberShips;
        Bookings = bookings;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}