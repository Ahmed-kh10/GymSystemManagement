using GymSystemmanagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GymSystemmanagement.DAL.Configuration
{
    internal class MemberConfigurations : GymUserConfigurations<Member> , IEntityTypeConfiguration<Member>
    {
        public new void configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.CreatedAt)
                   .HasColumnName("Joindate")
                   .HasDefaultValueSql("GETDATE()");
            
            base.Configure(builder);
        }
    }
}
