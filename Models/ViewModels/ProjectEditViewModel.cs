using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class ProjectEditViewModel
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
    }
}
