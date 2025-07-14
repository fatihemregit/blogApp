using BlogApp.Models.IWriterRepository;

namespace BlogApp.Data.Abstracts.Writer
{
    public interface IWriterRepository
    {

        //Create
        Task<IWriterRepositoryCrateOneWriterAsyncResponse?> CrateOneWriterAsync(IWriterRepositoryCrateOneWriterAsyncRequest writer);


        //Read
        Task<IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse?> GetOneWriterWithWriterIdAsync(IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest writer);

        Task<List<IWriterRepositoryGetAllWriterAsyncResponse>?> GetAllWriterAsync();


        //Update
        Task<IWriterRepositoryUpdateOneWriterResponse?> UpdateOneWriter(IWriterRepositoryUpdateOneWriterRequest writer);

        //Delete

        Task<bool> DeleteOneWriter(IWriterRepositoryDeleteOneWriterRequest writer);


    }



}
