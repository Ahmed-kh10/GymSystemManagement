namespace GymSystemmanagement.DAL.Models
{
    public class Healthrecord : BaseEntity
    {
        public decimal Height { get; set; }
        public decimal weight { get; set; }
        public string? Note {  get; set; }
        public string BloodType { get; set; }
        public Member Member { get; set; } = default!;
        public int MemberId { get; set; }
    }
}
