namespace BlogApp.Models.IAuthUserService
{
    public class IAuthUserServiceSignInRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Sifre { get; set; }

    }
}