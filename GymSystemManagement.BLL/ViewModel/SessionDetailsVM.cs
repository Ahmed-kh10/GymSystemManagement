public class SessionDetailsVM
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string TrainerName { get; set; }

    public int Capacity { get; set; }
    public int AvailableSlots { get; set; }

    public string Status { get; set; }

    public string StartDate { get; set; }
    public string EndDate { get; set; }

    public TimeSpan Duration { get; set; }
}