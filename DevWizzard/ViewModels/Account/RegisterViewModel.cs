using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email is required!")]

        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string firstName { get; set; }
        [Required, MaxLength(100)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "password is required!")]
        public string password { get; set; }
        [Compare("password",ErrorMessage ="confirm password does not match")]
        public string confirmPassword { get; set; }

        public byte[] Image { get; set; }

        public byte[] picture { get; set; }
    }
}
