using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels.AccountViewModels
{
    public class SignUpViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string Password { get; set; }
        
    }
}
