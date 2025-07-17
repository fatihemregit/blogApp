using BlogApp.Models.IAuthUserService;

namespace BlogApp.Business.Abstracts.Auth
{
    public interface IAuthUserService
    {
        Task<List<IAuthUserServiceGetAllUsersAsyncResponse>> GetAllUsersAsync();

        Task<IAuthUserServiceGetOneUserAsyncResponse> GetOneUserAsync(IAuthUserServiceGetOneUserAsyncRequest user);


        Task<IAuthUserServiceSignInResponse> SignIn(IAuthUserServiceSignInRequest user);

        Task<bool> Login(IAuthUserServiceLoginRequest user);
        Task Logout();

        Task<bool> DeleteUser(string userName);

        Task<bool> checkUserIsLogin(string userName);

        Task<IAuthUserServiceFindLocalUserwithUserNameResponse?> findLocalUserwithUserName(string userName);

        Task<Dictionary<string, bool>> checkRoleswithLocalUserName(string userName, List<string> roleNames);

    }
}
