using System.ComponentModel.DataAnnotations;

public class SessionEditVM
{
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public int TrainerId { get; set; }
}