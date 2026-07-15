namespace GymSystemManagement.BLL.ViewModels.Bookings;

public class SessionViewModel
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public string TrainerName { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public int AvailableSlots { get; set; }

    public string Status { get; set; } = string.Empty;

    public string DateDisplay { get; set; } = string.Empty;

    public string TimeRangeDisplay { get; set; } = string.Empty;

    public string Duration { get; set; } = string.Empty;
}