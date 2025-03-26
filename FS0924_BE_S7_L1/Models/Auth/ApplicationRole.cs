using Microsoft.AspNetCore.Identity;

namespace FS0924_BE_S7_L1.Models.Auth
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
