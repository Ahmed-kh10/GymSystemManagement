using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymSystemmanagement.DAL.Data
{
    public class GymSystemManagementDbContext : DbContext
    {
        public GymSystemManagementDbContext(
            DbContextOptions<GymSystemManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Healthrecord> Healthrecords { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
    }
}