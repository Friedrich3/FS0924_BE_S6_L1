using Microsoft.AspNetCore.Identity;

namespace FS0924_BE_S6_L1.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
