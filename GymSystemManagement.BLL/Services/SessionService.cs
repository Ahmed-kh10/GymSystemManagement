using GymSystemmanagement.DAL.Models;

public class SessionService : ISessionService
{
    private readonly IUnitOfWork _unit;

    public SessionService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<SessionIndexVM>> GetAllAsync()
    {
        var sessions = await _unit.Sessions.GetAllAsync();

        return sessions.Select(session => new SessionIndexVM
        {
            Id = session.Id,
            Description = session.Description,
            CategoryName = session.Category?.CategoryName ?? "",
            TrainerName = session.Trainer?.Name ?? "",
            Capacity = session.Capacity,
            AvailableSlots = session.Capacity - (session.SessionMembers?.Count ?? 0),

            Status =
                DateTime.Now < session.StartDate ? "Upcoming" :
                DateTime.Now > session.EndDate ? "Finished" :
                "Ongoing",

            DateDisplay = session.StartDate.ToString("dd MMM yyyy"),

            TimeRangeDisplay =
                $"{session.StartDate:hh:mm tt} - {session.EndDate:hh:mm tt}",

            Duration = (session.EndDate - session.StartDate).ToString(@"hh\:mm")
        }).ToList();
    }

    public async Task<SessionDetailsVM?> GetByIdAsync(int id)
    {
        var session = await _unit.Sessions.GetByIdAsync(id);

        if (session == null)
            return null;

        return new SessionDetailsVM
        {
            Id = session.Id,
            Description = session.Description,
            CategoryName = session.Category?.CategoryName ?? "",
            TrainerName = session.Trainer?.Name ?? "",
            Capacity = session.Capacity,
            AvailableSlots = session.Capacity - (session.SessionMembers?.Count ?? 0),

            Status =
                DateTime.Now < session.StartDate ? "Upcoming" :
                DateTime.Now > session.EndDate ? "Finished" :
                "Ongoing",

            StartDate = session.StartDate.ToString("dd MMM yyyy hh:mm tt"),
            EndDate = session.EndDate.ToString("dd MMM yyyy hh:mm tt"),
            Duration = session.EndDate - session.StartDate
        };
    }

    public async Task CreateAsync(SessionCreateVM vm)
    {
        Session session = new Session
        {
            Description = vm.Description,
            Capacity = vm.Capacity,
            StartDate = vm.StartDate,
            EndDate = vm.EndDate,
            TrainerId = vm.TrainerId,
            CategoryId = vm.CategoryId,
            CreatedAt = DateTime.Now
        };

        await _unit.Sessions.AddAsync(session);
        await _unit.SaveAsync();
    }

    public async Task UpdateAsync(int id, SessionEditVM vm)
    {
        var session = await _unit.Sessions.GetByIdAsync(id);

        if (session == null)
            throw new Exception("Session Not Found");

        session.Description = vm.Description;
        session.TrainerId = vm.TrainerId;
        session.StartDate = vm.StartDate;
        session.EndDate = vm.EndDate;
        session.UpdatedAt = DateTime.Now;

        await _unit.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unit.Sessions.DeleteAsync(id);
        await _unit.SaveAsync();
    }
    public async Task<int> GetUpcomingCountAsync()
    {
        var sessions = await _unit.Sessions.GetAllAsync();

        return sessions.Count(s => s.StartDate > DateTime.Now);
    }

    public async Task<int> GetOngoingCountAsync()
    {
        var sessions = await _unit.Sessions.GetAllAsync();

        return sessions.Count(s =>
            s.StartDate <= DateTime.Now &&
            s.EndDate >= DateTime.Now);
    }

    public async Task<int> GetCompletedCountAsync()
    {
        var sessions = await _unit.Sessions.GetAllAsync();

        return sessions.Count(s => s.EndDate < DateTime.Now);
    }
}