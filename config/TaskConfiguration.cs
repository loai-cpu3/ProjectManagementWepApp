using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.config
{
    public class TaskConfiguration : IEntityTypeConfiguration<Models.TaskEntity>
    {
        public void Configure(EntityTypeBuilder<Models.TaskEntity> builder)
        {
         
            builder.HasKey(t => t.TaskId);
            builder.Property(t => t.TaskTitle).IsRequired().HasMaxLength(50);
            builder.Property(t => t.TaskDescription).IsRequired().HasMaxLength(255);
            builder.Property(t => t.ProjectId).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.DueDate).IsRequired();
            builder.Property(t => t.Priority).IsRequired();
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.TaskId).ValueGeneratedOnAdd();
            builder.Property(t => t.Status).HasConversion(v => v.ToString(), v => (TaskEntityStatus)System.Enum.Parse(typeof(TaskEntityStatus), v));
            builder.Property(t => t.Priority).HasConversion(v => v.ToString(), v => (Priority)System.Enum.Parse(typeof(Priority), v));

            builder.HasOne(t => t.Project).WithMany(p => p.Tasks).HasForeignKey(t => t.ProjectId);
            
            


        }
    }
}
