namespace GymSystemmanagement.DAL.Models
{
    public class Member : GymUser
    {
        public string? Photo { get; set; }

        public Healthrecord Healthrecord { get; set; }
        public ICollection<MemberShip> MemberShips { get; set; } = default!;
        public ICollection<Booking> MemberSessions { get; set; } = default!;
    }
}
