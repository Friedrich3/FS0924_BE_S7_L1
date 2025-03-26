using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FS0924_BE_S7_L1.Models.Auth
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(RoleId))]
        public ApplicationRole Role { get; set; }


    public DateTime Date {  get; set; }
    }
}
