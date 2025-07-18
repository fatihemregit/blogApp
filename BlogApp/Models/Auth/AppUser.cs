using Microsoft.AspNetCore.Identity;

namespace BlogApp.Models.Auth
{
    public class AppUser:IdentityUser<Guid>
    {

        public bool isDelete { get; set; } = false;

        // Navigation Property: One AppUser has one Writer
        public Writer Writer { get; set; }
    }
}
