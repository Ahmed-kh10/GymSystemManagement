using GymSystemmanagement.DAL.Models.Enums;

namespace GymSystemmanagement.DAL.Models
{
    public class Trainer : GymUser
    {
        public Specialty Specialty { get; set; }
        public ICollection<Session> Sessions { get; set; } = default!;
    }
}
