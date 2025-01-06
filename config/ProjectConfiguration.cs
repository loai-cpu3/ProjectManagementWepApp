using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>

    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ProjectDescription).IsRequired().HasMaxLength(255);
            builder.Property(p => p.ProjectId).ValueGeneratedOnAdd();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p=>p.Status).HasConversion(v=>v.ToString(),v=> (ProjectStatus)Enum.Parse(typeof(ProjectStatus),v));


            builder.HasOne(p => p.Owner).WithMany(u => u.OwnedProjects).HasForeignKey(p => p.CreatedBy).OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(p => p.ProjectParticipants)
           .WithOne(pu => pu.Project)
           .HasForeignKey(pu => pu.ProjectId)
           .OnDelete(DeleteBehavior.Restrict);



        }

      
    }
}
