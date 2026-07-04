using GymSystemmanagement.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;


namespace GymSystemmanagement.DAL.Models
{
    public abstract class GymUser : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Gender Gender { get; set; }
    }
    [Owned]
    public class Address
    {
        public string City { get; set; }
        public string street { get; set; }
        public int Building { get; set; }
    }
}
