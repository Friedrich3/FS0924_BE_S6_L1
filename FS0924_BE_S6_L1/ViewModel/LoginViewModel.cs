using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S6_L1.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }

    }
}
