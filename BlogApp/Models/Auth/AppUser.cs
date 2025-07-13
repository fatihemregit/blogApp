using Microsoft.AspNetCore.Identity;

namespace BlogApp.Models.Auth
{
    public class AppUser:IdentityUser<Guid>
    {
        // Navigation Property: One AppUser has one Writer
        public Writer Writer { get; set; }
    }
}
