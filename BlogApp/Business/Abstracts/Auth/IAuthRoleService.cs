using BlogApp.Models.IAuthRoleService;

namespace BlogApp.Business.Abstracts.Auth
{
    public interface IAuthRoleService
    {
        Task<bool> CreateRolePost(IAuthRoleServiceCreateRolePostRequest role);

        Task<List<IAuthRoleServiceGetAllRolesAsync>> DeleteRoleGet();

        Task<bool> DeleteRolePost(IAuthRoleServiceDeleteRolePostRequest role);

        Task<bool> SetRoleForUserGet(string userEmail);
        Task<bool> SetRoleForUserPost(List<IAuthRoleServiceSetRoleForUserPost> roles, string userEmail, string localUserName);
    }
}
