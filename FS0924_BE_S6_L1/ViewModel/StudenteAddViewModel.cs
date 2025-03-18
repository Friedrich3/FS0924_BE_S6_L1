using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S6_L1.ViewModel
{
    public class StudenteAddViewModel
    {

        [Required]
        public required Guid StudenteId { get; set; }

        [Required]
        [StringLength(50)]
        public required string? Nome { get; set; }
        [Required]
        [StringLength(50)]
        public required string? Cognome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(320)]
        public required string? Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public required DateTime? DataDiNascita { get; set; }
    }
}

