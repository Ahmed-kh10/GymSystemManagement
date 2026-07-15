using System.ComponentModel.DataAnnotations.Schema;

namespace GymSystemmanagement.DAL.Models
{
    public class MemberShip : BaseEntity
    {
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public  Plan Plan { get; set; }
        public int PlanId { get; set; }
        public DateTime EndDate { get; set; }
        [NotMapped]
        public string Status => EndDate > DateTime.Now ? "Active" : "Expired";
        [NotMapped]
        public bool IsActive => EndDate > DateTime.Now;
    }
}
