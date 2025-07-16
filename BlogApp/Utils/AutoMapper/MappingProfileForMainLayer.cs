using AutoMapper;
using BlogApp.Business.Abstracts.Writer;
using BlogApp.Models;
using BlogApp.Models.Auth;
using BlogApp.Models.IAuthRoleService;
using BlogApp.Models.IAuthUserService;
using BlogApp.Models.IBlogRepository;
using BlogApp.Models.IBlogService;
using BlogApp.Models.IWriterRepository;
using BlogApp.Models.IWriterService;
namespace BlogApp.Utils.AutoMapper
{
    public class MappingProfileForMainLayer:Profile
    {
        public MappingProfileForMainLayer()
        {


            //Data

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
            //Blog to IBlogRepositoryUpdateOneBlogAsyncResponse
            CreateMap<Blog, IBlogRepositoryUpdateOneBlogAsyncResponse>();
            CreateMap<IBlogRepositoryUpdateOneBlogAsyncResponse, Blog>();



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

            //IBlogService
            //IBlogServiceCreateOneBlogAsyncRequest to IBlogRepositoryCreateOneBlogAsyncRequest
            CreateMap<IBlogServiceCreateOneBlogAsyncRequest, IBlogRepositoryCreateOneBlogAsyncRequest>();
            CreateMap<IBlogRepositoryCreateOneBlogAsyncRequest, IBlogServiceCreateOneBlogAsyncRequest>();
            //IBlogServiceCreateOneBlogAsyncResponse to IBlogRepositoryCreateOneBlogAsyncResponse
            CreateMap<IBlogServiceCreateOneBlogAsyncResponse, IBlogRepositoryCreateOneBlogAsyncResponse>();
            CreateMap<IBlogRepositoryCreateOneBlogAsyncResponse, IBlogServiceCreateOneBlogAsyncResponse>();
            //IBlogServiceGetAllBlogAsyncResponse to IBlogRepositoryGetAllBlogAsyncResponse
            CreateMap<IBlogServiceGetAllBlogAsyncResponse, IBlogRepositoryGetAllBlogAsyncResponse>();
            CreateMap<IBlogRepositoryGetAllBlogAsyncResponse, IBlogServiceGetAllBlogAsyncResponse>();
            //IBlogServiceGetOneBlogWithIdAsyncRequest to IBlogRepositoryGetOneBlogWithBlogIdAsyncRequest
            CreateMap<IBlogServiceGetOneBlogWithIdAsyncRequest, IBlogRepositoryGetOneBlogWithBlogIdAsyncRequest>();
            CreateMap<IBlogRepositoryGetOneBlogWithBlogIdAsyncRequest, IBlogServiceGetOneBlogWithIdAsyncRequest>();
            //IBlogServiceGetOneBlogWithIdAsyncResponse to IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse
            CreateMap<IBlogServiceGetOneBlogWithIdAsyncResponse, IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse>();
            CreateMap<IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse, IBlogServiceGetOneBlogWithIdAsyncResponse>();
            //IBlogServiceUpdateOneBlogAsyncRequest to IBlogRepositoryUpdateOneBlogAsyncRequest
            CreateMap<IBlogServiceUpdateOneBlogAsyncRequest, IBlogRepositoryUpdateOneBlogAsyncRequest>();
            CreateMap<IBlogRepositoryUpdateOneBlogAsyncRequest, IBlogServiceUpdateOneBlogAsyncRequest>();
            //IBlogServiceUpdateOneBlogAsyncResponse to IBlogRepositoryUpdateOneBlogAsyncResponse
            CreateMap<IBlogServiceUpdateOneBlogAsyncResponse, IBlogRepositoryUpdateOneBlogAsyncResponse>();
            CreateMap<IBlogRepositoryUpdateOneBlogAsyncResponse, IBlogServiceUpdateOneBlogAsyncResponse>();
            //IBlogServiceDeleteOneBlogAsyncRequest to IBlogRepositoryDeleteOneBlogAsyncRequest
            CreateMap<IBlogServiceDeleteOneBlogAsyncRequest, IBlogRepositoryDeleteOneBlogAsyncRequest>();
            CreateMap<IBlogRepositoryDeleteOneBlogAsyncRequest, IBlogServiceDeleteOneBlogAsyncRequest>();

            //IWriterService
            //IWriterServiceCreateOneWriterAsyncRequest to IWriterRepositoryCrateOneWriterAsyncRequest
            CreateMap<IWriterServiceCreateOneWriterAsyncRequest, IWriterRepositoryCrateOneWriterAsyncRequest>();
            CreateMap<IWriterRepositoryCrateOneWriterAsyncRequest, IWriterServiceCreateOneWriterAsyncRequest>();
            //IWriterServiceCreateOneWriterAsyncResponse to IWriterRepositoryCrateOneWriterAsyncResponse
            CreateMap<IWriterServiceCreateOneWriterAsyncResponse, IWriterRepositoryCrateOneWriterAsyncResponse>();
            CreateMap<IWriterRepositoryCrateOneWriterAsyncResponse, IWriterServiceCreateOneWriterAsyncResponse>();
            //IWriterServiceGetOneWriterWithIdAsyncRequest to IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest
            CreateMap<IWriterServiceGetOneWriterWithIdAsyncRequest, IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest>();
            CreateMap<IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest, IWriterServiceGetOneWriterWithIdAsyncRequest>();
            //IWriterServiceGetOneWriterWithIdAsyncResponse to IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse
            CreateMap<IWriterServiceGetOneWriterWithIdAsyncResponse,IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse>();
            CreateMap<IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse, IWriterServiceGetOneWriterWithIdAsyncResponse>();
            //IWriterServiceGetAllWriterAsyncResponse to  IWriterRepositoryGetAllWriterAsyncResponse
            CreateMap<IWriterServiceGetAllWriterAsyncResponse, IWriterRepositoryGetAllWriterAsyncResponse>();
            CreateMap<IWriterRepositoryGetAllWriterAsyncResponse, IWriterServiceGetAllWriterAsyncResponse>();
            //IWriterServiceUpdateOneWriterAsyncRequest to IWriterRepositoryUpdateOneWriterRequest
            CreateMap<IWriterServiceUpdateOneWriterAsyncRequest, IWriterRepositoryUpdateOneWriterRequest>();
            CreateMap<IWriterRepositoryUpdateOneWriterRequest, IWriterServiceUpdateOneWriterAsyncRequest>();
            //IWriterServiceUpdateOneWriterAsyncResponse to IWriterRepositoryUpdateOneWriterResponse
            CreateMap<IWriterServiceUpdateOneWriterAsyncResponse, IWriterRepositoryUpdateOneWriterResponse>();
            CreateMap<IWriterRepositoryUpdateOneWriterResponse, IWriterServiceUpdateOneWriterAsyncResponse>();
            //IWriterServiceDeleteOneWriterAsyncRequest to IWriterRepositoryDeleteOneWriterRequest
            CreateMap<IWriterServiceDeleteOneWriterAsyncRequest, IWriterRepositoryDeleteOneWriterRequest>();
            CreateMap<IWriterRepositoryDeleteOneWriterRequest, IWriterServiceDeleteOneWriterAsyncRequest>();

        }
    }
}
