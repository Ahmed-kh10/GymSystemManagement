using GymSystemmanagement.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class MemberCreateVM
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    public string Phone { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public string City { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }

    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public string BloodType { get; set; }
    public string Note { get; set; }
    public string? Photo { get; set; }
}