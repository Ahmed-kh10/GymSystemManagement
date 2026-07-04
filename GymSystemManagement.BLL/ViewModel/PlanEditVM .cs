using System.ComponentModel.DataAnnotations;

public class PlanEditVM
{
    public int Id { get; set; }

    [Required]
    public string PlanName { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int DurationDays { get; set; }

    [Required]
    public decimal Price { get; set; }
}