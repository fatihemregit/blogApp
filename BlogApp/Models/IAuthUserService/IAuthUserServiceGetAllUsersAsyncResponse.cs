namespace BlogApp.Models.IAuthUserService
{
    public class IAuthUserServiceGetAllUsersAsyncResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public IList<string> Roles { get; set; }//belki lazım olabilir

        public string SecurityStamp { get; set; }
        public string PasswordHash { get; set; }
    }
}