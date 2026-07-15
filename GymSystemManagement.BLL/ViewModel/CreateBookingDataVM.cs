using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymSystemManagement.BLL.ViewModels.Bookings;

public class CreateBookingDataVM
{
    public CreateBookingViewModel Booking { get; set; } = new();

    public List<SelectListItem> Members { get; set; } = [];
}