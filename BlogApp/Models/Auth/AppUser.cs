using Microsoft.AspNetCore.Identity;

namespace BlogApp.Models.Auth
{
    public class AppUser:IdentityUser<Guid>
    {
        //writer objesi yazılacak
        //public Guid WriterId { get; set; }
    }
}
