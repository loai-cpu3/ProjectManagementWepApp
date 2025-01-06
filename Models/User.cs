using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public  class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }

        // Navigation properties

        public List<UserTask> UserTasks { get; set; }
        public List<ProjectUser> ParticipatedProjects { get; set; }

        public List<Project> OwnedProjects { get; set; }



    }

 
}
