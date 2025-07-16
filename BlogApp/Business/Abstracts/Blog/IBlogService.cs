using BlogApp.Models.IBlogService;

namespace BlogApp.Business.Abstracts.Blog
{
    public interface IBlogService
    {
        //Create
        Task<IBlogServiceCreateOneBlogAsyncResponse> CreateOneBlogAsync(IBlogServiceCreateOneBlogAsyncRequest blog);
        //Read
        Task<IBlogServiceGetOneBlogWithIdAsyncResponse> GetOneBlogWithIdAsync(IBlogServiceGetOneBlogWithIdAsyncRequest blog);
        Task<List<IBlogServiceGetAllBlogAsyncResponse>> GetAllBlogAsync();
        //Update
        Task<IBlogServiceUpdateOneBlogAsyncResponse> UpdateOneBlogAsync(IBlogServiceUpdateOneBlogAsyncRequest blog);
        //Delete
        Task<bool> DeleteOneBlogAsync(IBlogServiceDeleteOneBlogAsyncRequest blog);
    }

}
