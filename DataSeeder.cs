using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DataSeeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "User", "Manager" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        public static async Task SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin@123";

            // Check if admin user exists
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new User
                {
                    UserName = "admin",
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                // Create admin user
                var result = await userManager.CreateAsync(adminUser, adminPassword);

                // Assign "Admin" role
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        public static async Task SeedApplicationData(AppDbContext context, UserManager<User> userManager)
        {
            // Get the default admin user
            var adminUser = await userManager.FindByNameAsync("admin");

            if (adminUser != null)
            {
                if (!context.Projects.Any())
                {
                    var project = new Project
                    {
                        ProjectName = "Default Project",
                        ProjectDescription = "This is a seeded project.",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(1),
                        Status = ProjectStatus.InProgress,
                        CreatedBy = adminUser.Id,
                        Owner = adminUser
                    };

                    context.Projects.Add(project);

                    context.Tasks.Add(new TaskEntity
                    {
                        TaskTitle = "Sample Task",
                        TaskDescription = "This is a sample task for the seeded project.",
                        Project = project,
                        CreatedAt = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(7),
                        Priority = Priority.Medium,
                        Status = TaskEntityStatus.ToDo
                    });

                    await context.SaveChangesAsync();
                }
            }
        }


    }
}
