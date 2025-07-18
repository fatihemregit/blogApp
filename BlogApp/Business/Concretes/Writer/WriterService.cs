using AutoMapper;
using Azure;
using BlogApp.Business.Abstracts.Writer;
using BlogApp.Data.Abstracts.Writer;
using BlogApp.Models.Auth;
using BlogApp.Models.Exceptions;
using BlogApp.Models.IWriterRepository;
using BlogApp.Models.IWriterService;
using BlogApp.Utils.Functions;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Business.Concretes.Writer
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public WriterService(IWriterRepository repository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IWriterServiceCreateOneWriterAsyncResponse> CreateOneWriterAsync(IWriterServiceCreateOneWriterAsyncRequest writer)
        {
            if (CustomNullChecker.nullCheckObjectProps(writer))
            { 
                throw new WriterServiceException("writer parameter is null");

            }
            writer.Description = (writer.Description is null) ? "" : writer.Description;
            writer.profileUrl = (writer.profileUrl is null) ? "" : writer.profileUrl;

            IWriterRepositoryCrateOneWriterAsyncRequest request = _mapper.Map<IWriterRepositoryCrateOneWriterAsyncRequest>(writer);
            IWriterRepositoryCrateOneWriterAsyncResponse? response = await _repository.CrateOneWriterAsync(request);
            if (CustomNullChecker.nullCheckObjectProps(response))
            {
                throw new WriterServiceException("response is null");
            }
            AppUser? foundUser = await _userManager.FindByIdAsync(writer.AppUserId.ToString());
            await _userManager.RemoveFromRoleAsync(foundUser, "Writer_CreateWriter");
            await _userManager.AddToRoleAsync(foundUser, "Blog_CreateBlog");
            await _userManager.AddToRoleAsync(foundUser, "Blog_UpdateBlog");
            return _mapper.Map<IWriterServiceCreateOneWriterAsyncResponse>(response);

        }

        public async Task<IWriterServiceGetOneWriterWithIdAsyncResponse> GetOneWriterWithIdAsync(IWriterServiceGetOneWriterWithIdAsyncRequest writer)
        {
            if (CustomNullChecker.nullCheckObjectProps(writer))
            {
                throw new WriterServiceException("writer parameter is null");

            }
            IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest request = _mapper.Map<IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest>(writer);
            IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse? response = await _repository.GetOneWriterWithWriterIdAsync(request);
            if (CustomNullChecker.nullCheckObjectProps(response))
            {
                throw new WriterServiceException("response is null");
            }
            return _mapper.Map<IWriterServiceGetOneWriterWithIdAsyncResponse>(response);
        }

        public async Task<List<IWriterServiceGetAllWriterAsyncResponse>> GetAllWriterAsync()
        {
            List<IWriterRepositoryGetAllWriterAsyncResponse>? response = await _repository.GetAllWriterAsync();
            if (CustomNullChecker.nullCheckObjectProps(response))
            {
                throw new WriterServiceException("response is null");
            }
            return _mapper.Map<List<IWriterServiceGetAllWriterAsyncResponse>>(response);
        }
        public async Task<int> GetWriterIdWithAppUserName(string username)
        {
            //null check
            if (CustomNullChecker.nullCheckObjectProps(new {userName = username}))
            { 
                throw new WriterServiceException("userName parameter is null");
            }
            AppUser? foundUser = await _userManager.FindByNameAsync(username);
            if (CustomNullChecker.nullCheckObjectProps(foundUser))
            {
                throw new WriterServiceException("user not found");

            }
            List<IWriterRepositoryGetAllWriterAsyncResponse>? allWritersInDb = await _repository.GetAllWriterAsync();
            if (CustomNullChecker.nullCheckObjectProps(allWritersInDb))
            {
                throw new WriterServiceException("does not have writer");
            }
            IWriterRepositoryGetAllWriterAsyncResponse? writerInDb = allWritersInDb.Where(w => w.AppUserId == foundUser.Id).FirstOrDefault();
            if (CustomNullChecker.nullCheckObjectProps(writerInDb))
            {
                throw new WriterServiceException("Writer Not Found");
            }
            return writerInDb.Id;
        }


        public async Task<IWriterServiceUpdateOneWriterAsyncResponse> UpdateOneWriterAsync(IWriterServiceUpdateOneWriterAsyncRequest writer)
        {
            if (CustomNullChecker.nullCheckObjectProps(writer))
            {
                throw new WriterServiceException("writer parameter is null");

            }
            writer.Description = (writer.Description is null) ? "" : writer.Description;
            writer.profileUrl = (writer.profileUrl is null) ? "" : writer.profileUrl;

            IWriterRepositoryUpdateOneWriterRequest request = _mapper.Map<IWriterRepositoryUpdateOneWriterRequest>(writer);
            IWriterRepositoryUpdateOneWriterResponse? response = await _repository.UpdateOneWriter(request);
            if (CustomNullChecker.nullCheckObjectProps(response))
            {
                throw new WriterServiceException("response is null");
            }
            return _mapper.Map<IWriterServiceUpdateOneWriterAsyncResponse>(response);
        }
        public async Task<bool> DeleteOneWriterAsync(IWriterServiceDeleteOneWriterAsyncRequest writer)
        {
            if (CustomNullChecker.nullCheckObjectProps(writer) )
            {
                throw new WriterServiceException("writer parameter is null");

            }
            IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse? foundWriterWithId = await _repository.GetOneWriterWithWriterIdAsync(new IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest { Id = writer.Id });
            AppUser? foundUser = await _userManager.FindByIdAsync(foundWriterWithId.AppUserId.ToString());
            await _userManager.AddToRoleAsync(foundUser, "Writer_CreateWriter");
            await _userManager.RemoveFromRoleAsync(foundUser, "Blog_CreateBlog");
            await _userManager.RemoveFromRoleAsync(foundUser, "Blog_UpdateBlog");
            IWriterRepositoryDeleteOneWriterRequest request = _mapper.Map<IWriterRepositoryDeleteOneWriterRequest>(writer);
            bool response = await _repository.DeleteOneWriter(request);
            if (!response)
            {
                throw new WriterServiceException("response is false");   
            }

            

            return response;

        }


    }
}
