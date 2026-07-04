public class SessionIndexVM
{
    public int Id { get; set; }

    public string Description { get; set; }

    public string CategoryName { get; set; }
    public string TrainerName { get; set; }

    public string Status { get; set; }

    public string DateDisplay { get; set; }
    public string TimeRangeDisplay { get; set; }

    public string Duration { get; set; }

    public int Capacity { get; set; }
    public int AvailableSlots { get; set; }
}