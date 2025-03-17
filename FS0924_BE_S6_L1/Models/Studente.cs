using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S6_L1.Models
{
    public class Studente
    {
        [Key]
        public Guid StudenteId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string? Cognome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(320)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataDiNascita { get; set; }
    }
}
