using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string password { get; set; }

    }
}
