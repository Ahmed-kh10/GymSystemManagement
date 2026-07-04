using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymSystemmanagement.DAL.Configuration
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(x => x.Name)
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasColumnType("nvarchar(200)")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Price)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(x => x.DurationDays)
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}