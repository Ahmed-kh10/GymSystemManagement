namespace GymSystemmanagement.DAL.Models
{
    public class Session : BaseEntity
    {  
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; } = default!;
        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; }
        public ICollection<Booking> SessionMembers { get; set; } = default!;
    }
}
