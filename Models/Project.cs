using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string ProjectName { get; set; }
        [Required]
        [Display(Name = "Project Description")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string ProjectDescription { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Due Date")]
       
        [DataType(DataType.Date)]
        [DateGreaterThan("StartDate", ErrorMessage = "End Date must be greater than Start Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Project Status")]
        public ProjectStatus Status { get; set; }
        public String CreatedBy { get; set; }
        public User Owner { get; set; }

        public List<TaskEntity> Tasks { get; set; }
        public List<ProjectUser> ProjectParticipants { get; set; }



    }
    public enum ProjectStatus
    {
        [Display(Name = "Not Started")]
        NotStarted = 0,
        [Display(Name = "In Progress")]
        InProgress = 1,
        Completed = 2
    }

}
