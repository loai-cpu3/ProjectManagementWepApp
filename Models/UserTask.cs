namespace WebApplication1.Models
{
    public class UserTask
    {
        public String UserId { get; set; }
        public User User { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }

    }
}
