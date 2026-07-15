using GymSystemManagement.BLL.ViewModels.Bookings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _bookingService.GetSessionsAsync();
        return View(model);
    }

    public async Task<IActionResult> GetMembersForUpcomingSession(int id)
    {
        var model = await _bookingService.GetMembersForUpcomingSessionAsync(id);
        return View(model);
    }

    public async Task<IActionResult> GetMembersForOngoingSession(int id)
    {
        var model = await _bookingService.GetMembersForOngoingSessionAsync(id);
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        var model = await _bookingService.PrepareCreateAsync(id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateBookingDataVM vm)
    {
        if (!ModelState.IsValid)
        {
            var data = await _bookingService.PrepareCreateAsync(vm.Booking.SessionId);
            data.Booking = vm.Booking;
            return View(data);
        }

        try
        {
            await _bookingService.CreateAsync(vm.Booking);

            TempData["SuccessMessage"] = "Booking Created Successfully";

            return RedirectToAction(
                nameof(GetMembersForUpcomingSession),
                new { id = vm.Booking.SessionId });
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;

            var data = await _bookingService.PrepareCreateAsync(vm.Booking.SessionId);
            data.Booking = vm.Booking;

            return View(data);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int memberId, int sessionId)
    {
        try
        {
            await _bookingService.CancelAsync(memberId, sessionId);

            TempData["SuccessMessage"] = "Booking Cancelled Successfully";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return RedirectToAction(
            nameof(GetMembersForUpcomingSession),
            new { id = sessionId });
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Attended(int memberId, int sessionId)
    {
        try
        {
            await _bookingService.MarkAttendanceAsync(memberId, sessionId);

            TempData["SuccessMessage"] = "Attendance Marked Successfully";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return RedirectToAction(
            nameof(GetMembersForOngoingSession),
            new { id = sessionId });
    }
}