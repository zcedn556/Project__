using Microsoft.AspNetCore.Identity;

namespace Project.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }
    }
}
