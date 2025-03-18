using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S6_L1.ViewModel
{
    public class StudenteEditViewModel
    {
        public required Guid StudenteId { get; set; }
        public required string? Nome { get; set; } 
        public required string? Cognome { get; set; }        
        public required string? Email { get; set; }      
        public required DateTime? DataDiNascita { get; set; }
    }
}
