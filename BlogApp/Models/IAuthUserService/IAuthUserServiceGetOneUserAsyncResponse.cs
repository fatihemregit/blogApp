namespace BlogApp.Models.IAuthUserService
{
    public class IAuthUserServiceGetOneUserAsyncResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
