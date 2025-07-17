using Microsoft.AspNetCore.Identity;

namespace BlogApp.Models.Exceptions
{
    public class IdentityException : CustomException
    {
        public IdentityException(string? message) : base(message, 401, 401)
        {
        }
    }
}
