using Microsoft.AspNetCore.Identity;

namespace BlogApp.Models.IAuthUserService
{
    public class IAuthUserServiceSignInResponse
    {
        public bool result { get; set; }
        public IEnumerable<IdentityError>? identityErrors { get; set; }
    }
}
