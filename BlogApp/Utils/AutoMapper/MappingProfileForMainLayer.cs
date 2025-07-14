using AutoMapper;
using BlogApp.Models;
using BlogApp.Models.Auth;
using BlogApp.Models.IAuthRoleService;
using BlogApp.Models.IAuthUserService;
using BlogApp.Models.IBlogRepository;
using BlogApp.Models.IWriterRepository;
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


            //IWriterRepository
            //Writer to IWriterRepositoryCrateOneWriterAsyncRequest
            CreateMap<Writer, IWriterRepositoryCrateOneWriterAsyncRequest>();
            CreateMap<IWriterRepositoryCrateOneWriterAsyncRequest, Writer>();
            //Writer to IWriterRepositoryCrateOneWriterAsyncResponse
            CreateMap<Writer, IWriterRepositoryCrateOneWriterAsyncResponse>();
            CreateMap<IWriterRepositoryCrateOneWriterAsyncResponse, Writer>();
            //Writer to IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse
            CreateMap<Writer, IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse>();
            CreateMap<IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse, Writer>();
            //Writer to IWriterRepositoryUpdateOneWriterResponse
            CreateMap<Writer, IWriterRepositoryUpdateOneWriterResponse>();
            CreateMap<IWriterRepositoryUpdateOneWriterResponse, Writer>();

            //IBlogRepository
            //Blog to IBlogRepositoryCreateOneBlogAsyncRequest
            CreateMap<Blog, IBlogRepositoryCreateOneBlogAsyncRequest>();
            CreateMap<IBlogRepositoryCreateOneBlogAsyncRequest, Blog>();
            //Blog to IBlogRepositoryCreateOneBlogAsyncResponse
            CreateMap<Blog, IBlogRepositoryCreateOneBlogAsyncResponse>();
            CreateMap<IBlogRepositoryCreateOneBlogAsyncResponse, Blog>();
            //Blog to IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse
            CreateMap<Blog, IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse>();
            CreateMap<IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse, Blog>();
            //Blog to IBlogRepositoryGetAllBlogAsyncResponse
            CreateMap<Blog, IBlogRepositoryGetAllBlogAsyncResponse>();
            CreateMap<IBlogRepositoryGetAllBlogAsyncResponse, Blog>();
            //Blog to IBlogRepositoryUpdateOneBlogResponse
            CreateMap<Blog, IBlogRepositoryUpdateOneBlogResponse>();
            CreateMap<IBlogRepositoryUpdateOneBlogResponse, Blog>();


        }
    }
}
