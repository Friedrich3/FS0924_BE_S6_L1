using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S6_L1.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(320)]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateOnly BirthDate { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 8)]
        public required string Password { get; set; }
        [Compare("Password")]
        [StringLength(256, MinimumLength = 8)]
        public required string ConfermaPassword { get; set; }
    }
}
