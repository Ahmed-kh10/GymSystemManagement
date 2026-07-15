using GymSystemmanagement.DAL.Models.Enums;
using Microsoft.AspNetCore.Http;

public class MemberEditVM
{
    public int Id { get; set; }

    public string Name { get; set; }
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
    public string? Note { get; set; }

    public string? CurrentPhoto { get; set; }

    public IFormFile? Photo { get; set; }
}