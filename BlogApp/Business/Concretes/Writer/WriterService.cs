using AutoMapper;
using Azure;
using BlogApp.Business.Abstracts.Writer;
using BlogApp.Data.Abstracts.Writer;
using BlogApp.Models.Auth;
using BlogApp.Models.Exceptions;
using BlogApp.Models.IWriterRepository;
using BlogApp.Models.IWriterService;
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
            if (writer is null)
            { 
                throw new WriterServiceException("writer parameter is null");

            }
            writer.Description = (writer.Description is null) ? "" : writer.Description;
            writer.profileUrl = (writer.profileUrl is null) ? "" : writer.profileUrl;

            IWriterRepositoryCrateOneWriterAsyncRequest request = _mapper.Map<IWriterRepositoryCrateOneWriterAsyncRequest>(writer);
            IWriterRepositoryCrateOneWriterAsyncResponse? response = await _repository.CrateOneWriterAsync(request);
            if (response is null)
            {
                throw new WriterServiceException("response is null");
            }
            return _mapper.Map<IWriterServiceCreateOneWriterAsyncResponse>(response);

        }

        public async Task<IWriterServiceGetOneWriterWithIdAsyncResponse> GetOneWriterWithIdAsync(IWriterServiceGetOneWriterWithIdAsyncRequest writer)
        {
            if (writer is null)
            {
                throw new WriterServiceException("writer parameter is null");

            }
            IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest request = _mapper.Map<IWriterRepositoryGetOneWriterWithWriterIdAsyncRequest>(writer);
            IWriterRepositoryGetOneWriterWithWriterIdAsyncResponse? response = await _repository.GetOneWriterWithWriterIdAsync(request);
            if (response is null)
            {
                throw new WriterServiceException("response is null");
            }
            return _mapper.Map<IWriterServiceGetOneWriterWithIdAsyncResponse>(response);
        }

        public async Task<List<IWriterServiceGetAllWriterAsyncResponse>> GetAllWriterAsync()
        {
            List<IWriterRepositoryGetAllWriterAsyncResponse>? response = await _repository.GetAllWriterAsync();
            if (response is null)
            {
                throw new WriterServiceException("response is null");
            }
            return _mapper.Map<List<IWriterServiceGetAllWriterAsyncResponse>>(response);
        }
        public async Task<int> GetWriterIdWithAppUserName(string username)
        {
            //null check
            if (username is null)
            { 
                throw new WriterServiceException("userName parameter is null");
            }
            AppUser? foundUser = await _userManager.FindByNameAsync(username);
            if (foundUser is null)
            {
                throw new WriterServiceException("user not found");

            }
            List<IWriterRepositoryGetAllWriterAsyncResponse>? allWritersInDb = await _repository.GetAllWriterAsync();
            if (allWritersInDb is null)
            {
                throw new WriterServiceException("does not have writer");
            }
            IWriterRepositoryGetAllWriterAsyncResponse? writerInDb = allWritersInDb.Where(w => w.AppUserId == foundUser.Id).FirstOrDefault();
            if (writerInDb is null)
            {
                throw new WriterServiceException("Writer Not Found");
            }
            return writerInDb.Id;
        }


        public async Task<IWriterServiceUpdateOneWriterAsyncResponse> UpdateOneWriterAsync(IWriterServiceUpdateOneWriterAsyncRequest writer)
        {
            if (writer is null)
            {
                throw new WriterServiceException("writer parameter is null");

            }
            writer.Description = (writer.Description is null) ? "" : writer.Description;
            writer.profileUrl = (writer.profileUrl is null) ? "" : writer.profileUrl;

            IWriterRepositoryUpdateOneWriterRequest request = _mapper.Map<IWriterRepositoryUpdateOneWriterRequest>(writer);
            IWriterRepositoryUpdateOneWriterResponse? response = await _repository.UpdateOneWriter(request);
            if (response is null)
            {
                throw new WriterServiceException("response is null");
            }
            return _mapper.Map<IWriterServiceUpdateOneWriterAsyncResponse>(response);
        }
        public async Task<bool> DeleteOneWriterAsync(IWriterServiceDeleteOneWriterAsyncRequest writer)
        {
            if (writer is null)
            {
                throw new WriterServiceException("writer parameter is null");

            }

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
