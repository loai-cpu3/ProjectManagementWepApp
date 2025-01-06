using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.config
{
    public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder.HasKey(pu => new { pu.UserId, pu.ProjectId });
            
            builder.Property(pu => pu.Role).IsRequired();
            builder.Property(pu => pu.Role).HasConversion(v => v.ToString(), v => (ProjectRole)Enum.Parse(typeof(ProjectRole), v));

            builder.HasOne(pu => pu.User)
           .WithMany(u => u.ParticipatedProjects)
           .HasForeignKey(pu => pu.UserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pu => pu.Project)
                .WithMany(pu => pu.ProjectParticipants)
                .HasForeignKey(pu => pu.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
