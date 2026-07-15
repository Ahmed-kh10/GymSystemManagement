using System.ComponentModel.DataAnnotations;

public class CreateMembershipVM
{
    [Required]
    public int MemberId { get; set; }

    [Required]
    public int PlanId { get; set; }
}