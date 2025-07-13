using AutoMapper;
using BlogApp.Models.Auth;
using BlogApp.Models.IAuthRoleService;
using BlogApp.Models.IAuthUserService;
namespace BlogApp.Utils.AutoMapper
{
    public class MappingProfileForMainLayer:Profile
    {
        public MappingProfileForMainLayer()
        {


            //Business
            //IAuthUserService
            //AppUser to IAuthUserServiceGetAllUsersAsyncResponse
            CreateMap<AppUser, IAuthUserServiceGetAllUsersAsyncResponse>();
            CreateMap<IAuthUserServiceGetAllUsersAsyncResponse, AppUser>();
            //AppUser to IAuthUserServiceSignInRequest
            CreateMap<AppUser, IAuthUserServiceSignInRequest>();
            CreateMap<IAuthUserServiceSignInRequest, AppUser>();
            //AppUser to IAuthUserServiceFindLocalUserwithUserNameResponse
            CreateMap<AppUser, IAuthUserServiceFindLocalUserwithUserNameResponse>();
            CreateMap<IAuthUserServiceFindLocalUserwithUserNameResponse, AppUser>();
            //IAuthRoleService
            //AppRole to IAuthRoleServiceCreateRolePostRequest
            CreateMap<AppRole, IAuthRoleServiceCreateRolePostRequest>();
            CreateMap<IAuthRoleServiceCreateRolePostRequest, AppRole>();
            //AppRole to IAuthRoleServiceGetAllRolesAsync
            CreateMap<AppRole, IAuthRoleServiceGetAllRolesAsync>();
            CreateMap<IAuthRoleServiceGetAllRolesAsync, AppRole>();
        }
    }
}
