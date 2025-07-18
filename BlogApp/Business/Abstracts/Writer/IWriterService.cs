using BlogApp.Models.IWriterService;

namespace BlogApp.Business.Abstracts.Writer
{
    public interface IWriterService
    {
        //Create
        Task<IWriterServiceCreateOneWriterAsyncResponse> CreateOneWriterAsync(IWriterServiceCreateOneWriterAsyncRequest writer);
        //Read
        Task<IWriterServiceGetOneWriterWithIdAsyncResponse> GetOneWriterWithIdAsync(IWriterServiceGetOneWriterWithIdAsyncRequest writer);
        Task<List<IWriterServiceGetAllWriterAsyncResponse>> GetAllWriterAsync();
        Task<int> GetWriterIdWithAppUserName(string username);

        //Update
        Task<IWriterServiceUpdateOneWriterAsyncResponse> UpdateOneWriterAsync(IWriterServiceUpdateOneWriterAsyncRequest writer);
        //Delete
        Task<bool> DeleteOneWriterAsync(IWriterServiceDeleteOneWriterAsyncRequest writer);

    }


}
