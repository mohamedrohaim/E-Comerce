using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Field Cannot Be Empty)")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password Field Cannot Be Empty)")]
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}
