using GymSystemManagement.BLL.ViewModels.Bookings;
using GymSystemmanagement.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unit;

    public BookingService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<List<SessionViewModel>> GetSessionsAsync()
    {
        var sessions = await _unit.Sessions.GetAllAsync();

        return sessions.Select(session => new SessionViewModel
        {
            Id = session.Id,
            Description = session.Description,
            CategoryName = session.Category.CategoryName,
            TrainerName = session.Trainer.Name,
            Capacity = session.Capacity,
            AvailableSlots = session.Capacity - session.SessionMembers.Count,

            Status = DateTime.Now < session.StartDate
                ? "Upcoming"
                : DateTime.Now > session.EndDate
                    ? "Finished"
                    : "Ongoing",

            DateDisplay = session.StartDate.ToString("dd MMM yyyy"),
            TimeRangeDisplay = $"{session.StartDate:hh:mm tt} - {session.EndDate:hh:mm tt}",
            Duration = (session.EndDate - session.StartDate).ToString(@"hh\:mm")
        }).ToList();
    }

    public async Task<List<MemberForSessionViewModel>> GetMembersForUpcomingSessionAsync(int sessionId)
    {
        var bookings = await _unit.Bookings.GetBySessionAsync(sessionId);

        return bookings.Select(x => new MemberForSessionViewModel
        {
            MemberId = x.MemberId,
            SessionId = x.SessionId,
            MemberName = x.Member.Name,
            BookingDate = x.CreatedAt.ToString("dd MMM yyyy"),
            IsAttended = x.IsAttended
        }).ToList();
    }

    public async Task<List<MemberForSessionViewModel>> GetMembersForOngoingSessionAsync(int sessionId)
    {
        var bookings = await _unit.Bookings.GetBySessionAsync(sessionId);

        return bookings.Select(x => new MemberForSessionViewModel
        {
            MemberId = x.MemberId,
            SessionId = x.SessionId,
            MemberName = x.Member.Name,
            BookingDate = x.CreatedAt.ToString("dd MMM yyyy"),
            IsAttended = x.IsAttended
        }).ToList();
    }

    public async Task<CreateBookingDataVM> PrepareCreateAsync(int sessionId)
    {
        var session = await _unit.Sessions.GetByIdAsync(sessionId);

        if (session == null)
            throw new Exception("Session Not Found");

        var members = await _unit.Members.GetAllAsync();

        var list = new List<SelectListItem>();

        foreach (var member in members)
        {
            var membership = await _unit.MemberShips.GetActiveMembershipAsync(member.Id);

            if (membership != null)
            {
                list.Add(new SelectListItem
                {
                    Value = member.Id.ToString(),
                    Text = member.Name
                });
            }
        }

        return new CreateBookingDataVM
        {
            Booking = new CreateBookingViewModel
            {
                SessionId = sessionId
            },
            Members = list
        };
    }

    public async Task CreateAsync(CreateBookingViewModel vm)
    {
        var session = await _unit.Sessions.GetByIdAsync(vm.SessionId);

        if (session == null)
            throw new Exception("Session Not Found");

        if (session.StartDate <= DateTime.Now)
            throw new Exception("Booking Is Allowed Only For Future Sessions");

        var membership = await _unit.MemberShips.GetActiveMembershipAsync(vm.MemberId);

        if (membership == null)
            throw new Exception("Member Doesn't Have Active Membership");

        var currentBookings = await _unit.Bookings.GetBySessionAsync(vm.SessionId);

        if (currentBookings.Count >= session.Capacity)
            throw new Exception("Session Is Full");

        var booking = await _unit.Bookings.GetAsync(vm.MemberId, vm.SessionId);

        if (booking != null)
            throw new Exception("Member Already Booked This Session");

        await _unit.Bookings.AddAsync(new Booking
        {
            MemberId = vm.MemberId,
            SessionId = vm.SessionId,
            IsAttended = false,
            CreatedAt = DateTime.Now
        });

        await _unit.SaveAsync();
    }

    public async Task CancelAsync(int memberId, int sessionId)
    {
        var booking = await _unit.Bookings.GetAsync(memberId, sessionId);

        if (booking == null)
            throw new Exception("Booking Not Found");

        var session = await _unit.Sessions.GetByIdAsync(sessionId);

        if (session == null)
            throw new Exception("Session Not Found");

        if (session.StartDate <= DateTime.Now)
            throw new Exception("Cannot Cancel Booking After Session Has Started");

        await _unit.Bookings.DeleteAsync(booking);

        await _unit.SaveAsync();
    }

    public async Task MarkAttendanceAsync(int memberId, int sessionId)
    {
        var booking = await _unit.Bookings.GetAsync(memberId, sessionId);

        if (booking == null)
            throw new Exception("Booking Not Found");

        var session = await _unit.Sessions.GetByIdAsync(sessionId);

        if (session == null)
            throw new Exception("Session Not Found");

        if (DateTime.Now < session.StartDate || DateTime.Now > session.EndDate)
            throw new Exception("Attendance Can Only Be Marked During Ongoing Session");

        booking.IsAttended = true;

        await _unit.SaveAsync();
    }
}