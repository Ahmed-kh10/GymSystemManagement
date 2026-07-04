using GymSystemmanagement.DAL.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class TrainerEditVM
{
    public int Id { get; set; }

    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public int BuildingNumber { get; set; }

    [Required]
    public Specialty Specialty { get; set; }
}