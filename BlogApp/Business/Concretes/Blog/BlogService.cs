using AutoMapper;
using Azure;
using BlogApp.Business.Abstracts.Blog;
using BlogApp.Data.Abstracts.Blog;
using BlogApp.Models.Exceptions;
using BlogApp.Models.IBlogRepository;
using BlogApp.Models.IBlogService;

namespace BlogApp.Business.Concretes.Blog
{
    public class BlogService : IBlogService
    {

        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;


        public BlogService(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IBlogServiceCreateOneBlogAsyncResponse> CreateOneBlogAsync(IBlogServiceCreateOneBlogAsyncRequest blog)
        {
            if (blog is null)
            {
                throw new BlogServiceException("blog parameters is null");
            }
            IBlogRepositoryCreateOneBlogAsyncRequest request = _mapper.Map<IBlogRepositoryCreateOneBlogAsyncRequest>(blog);
            IBlogRepositoryCreateOneBlogAsyncResponse? response = await _repository.CreateOneBlogAsync(request);
            if (response is null)
            {
                throw new BlogServiceException("response is null");
            }
            return _mapper.Map<IBlogServiceCreateOneBlogAsyncResponse>(response);
        }



        public async Task<List<IBlogServiceGetAllBlogAsyncResponse>> GetAllBlogAsync()
        {
            List<IBlogRepositoryGetAllBlogAsyncResponse>? response = await _repository.GetAllBlogAsync();
            if (response is null)
            {
                throw new BlogServiceException("response is null");
            }
            return _mapper.Map<List<IBlogServiceGetAllBlogAsyncResponse>>(response);

        }

        public async Task<IBlogServiceGetOneBlogWithIdAsyncResponse> GetOneBlogWithIdAsync(IBlogServiceGetOneBlogWithIdAsyncRequest blog)
        {
            if (blog is null)
            {
                throw new BlogServiceException("blog parameters is null");
            }
            IBlogRepositoryGetOneBlogWithBlogIdAsyncRequest request = _mapper.Map<IBlogRepositoryGetOneBlogWithBlogIdAsyncRequest>(blog);
            IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse? response = await _repository.GetOneBlogWithBlogIdAsync(request);
            if (response is null)
            {
                throw new BlogServiceException("response is null");
            }
            return _mapper.Map<IBlogServiceGetOneBlogWithIdAsyncResponse>(response);
        }

        public async Task<IBlogServiceUpdateOneBlogAsyncResponse> UpdateOneBlogAsync(IBlogServiceUpdateOneBlogAsyncRequest blog)
        {
            if (blog is null)
            {
                throw new BlogServiceException("blog parameters is null");
            }
            IBlogRepositoryUpdateOneBlogAsyncRequest request = _mapper.Map<IBlogRepositoryUpdateOneBlogAsyncRequest>(blog);
            IBlogRepositoryUpdateOneBlogAsyncResponse? response = await _repository.UpdateOneBlogAsync(request);
            if (response is null)
            {
                throw new BlogServiceException("response is null");
            }
            return _mapper.Map<IBlogServiceUpdateOneBlogAsyncResponse>(response);

        }

        public async Task<bool> DeleteOneBlogAsync(IBlogServiceDeleteOneBlogAsyncRequest blog)
        {
            if (blog is null)
            {
                throw new BlogServiceException("blog parameters is null");
            }
            IBlogRepositoryDeleteOneBlogAsyncRequest request = _mapper.Map<IBlogRepositoryDeleteOneBlogAsyncRequest>(blog);
            bool response = await _repository.DeleteOneBlogAsync(request);
            if (!response)
            {
                throw new BlogServiceException("response is false");
            }
            return response;
        }
    }
}
