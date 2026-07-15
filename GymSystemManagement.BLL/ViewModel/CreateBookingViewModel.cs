using System.ComponentModel.DataAnnotations;

namespace GymSystemManagement.BLL.ViewModels.Bookings;

public class CreateBookingViewModel
{
    [Required]
    public int MemberId { get; set; }

    [Required]
    public int SessionId { get; set; }
}