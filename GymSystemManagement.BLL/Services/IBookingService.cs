using GymSystemManagement.BLL.ViewModels.Bookings;

public interface IBookingService
{
    Task<List<SessionViewModel>> GetSessionsAsync();

    Task<List<MemberForSessionViewModel>> GetMembersForUpcomingSessionAsync(int sessionId);

    Task<List<MemberForSessionViewModel>> GetMembersForOngoingSessionAsync(int sessionId);

    Task<CreateBookingDataVM> PrepareCreateAsync(int sessionId);

    Task CreateAsync(CreateBookingViewModel vm);

    Task CancelAsync(int memberId, int sessionId);

    Task MarkAttendanceAsync(int memberId, int sessionId);
}