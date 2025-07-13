namespace BlogApp.Models.IAuthUserService
{
    public class IAuthUserServiceLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Persistent { get; set; }
    }
}