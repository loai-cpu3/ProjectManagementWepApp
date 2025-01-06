namespace WebApplication1.Models
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; } 
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }
         
        public TaskEntityStatus Status { get; set; }

        public List<UserTask> UserTasks { get; set; }
    }
    public enum TaskEntityStatus
    {
        ToDo = 0,
        InProgress = 1,
        Completed = 2
    }
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}
