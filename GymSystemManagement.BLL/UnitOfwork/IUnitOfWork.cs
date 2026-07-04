using GymSystemManagement.Repositories;

public interface IUnitOfWork
{
    IMemberRepository Members { get; }
    ITrainerRepository Trainers { get; }
    IPlanRepository Plans { get; }
    ISessionRepository Sessions { get; }
    ICategoryRepository Categories { get; }

    Task SaveAsync();
}