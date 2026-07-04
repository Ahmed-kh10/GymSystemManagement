using System.ComponentModel.DataAnnotations;

public class SessionCreateVM
{
    [Required]
    public string Description { get; set; }

    [Required]
    public int Capacity { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public int TrainerId { get; set; }

    [Required]
    public int CategoryId { get; set; }
}