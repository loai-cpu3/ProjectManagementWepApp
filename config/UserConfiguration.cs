using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired(false).HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired(false).HasMaxLength(50);
            builder.Property(u => u.ImageUrl).HasMaxLength(255).IsRequired(false);

            // Configure relationships
            builder.HasMany(u => u.ParticipatedProjects)
                .WithOne(pu => pu.User)
                .HasForeignKey(pu => pu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.OwnedProjects)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
