using GymSystemManagement.Repositories;
using GymSystemmanagement.DAL.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly GymSystemManagementDbContext _context;

    public IMemberRepository Members { get; }
    public ITrainerRepository Trainers { get; }
    public IPlanRepository Plans { get; }
    public ISessionRepository Sessions { get; }
    public ICategoryRepository Categories { get; }

    public UnitOfWork(
        GymSystemManagementDbContext context,
        IMemberRepository memberRepository,
        ITrainerRepository trainerRepository,
        IPlanRepository planRepository,
        ISessionRepository sessionRepository,
        ICategoryRepository categoryRepository)
    {
        _context = context;

        Members = memberRepository;
        Trainers = trainerRepository;
        Plans = planRepository;
        Sessions = sessionRepository;
        Categories = categoryRepository;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}