using BlogApp.Models.IBlogRepository;

namespace BlogApp.Data.Abstracts.Blog
{
    public interface IBlogRepository
    {
        //Create
        Task<IBlogRepositoryCreateOneBlogAsyncResponse?> CreateOneBlogAsync(IBlogRepositoryCreateOneBlogAsyncRequest blog);
        //Read
        Task<IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse?> GetOneBlogWithBlogIdAsync(IBlogRepositoryGetOneBlogWithBlogIdAsyncRequest blog);

        Task<List<IBlogRepositoryGetAllBlogAsyncResponse>?> GetAllBlogAsync();
        //Update
        Task<IBlogRepositoryUpdateOneBlogAsyncResponse?> UpdateOneBlogAsync(IBlogRepositoryUpdateOneBlogAsyncRequest blog);
        //Delete
        Task<bool> DeleteOneBlogAsync(IBlogRepositoryDeleteOneBlogAsyncRequest blog);


    }


}
