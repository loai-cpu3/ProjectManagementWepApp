namespace WebApplication1.Models
{
    public class ProjectUser
    {
        public String UserId { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ProjectRole Role { get; set; }
    }
}

namespace WebApplication1
{
    public enum ProjectRole
    {
        Memeber,
        Manager,
        Admin

    }
}