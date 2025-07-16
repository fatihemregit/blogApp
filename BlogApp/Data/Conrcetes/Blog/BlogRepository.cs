using AutoMapper;
using BlogApp.Data.Abstracts.Blog;
using BlogApp.Data.Context;
using BlogApp.Models;
using BlogApp.Models.IBlogRepository;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Conrcetes.Blog
{
    public class BlogRepository : IBlogRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;



        public BlogRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IBlogRepositoryCreateOneBlogAsyncResponse?> CreateOneBlogAsync(IBlogRepositoryCreateOneBlogAsyncRequest blog)
        {
            Models.Blog blogDto = _mapper.Map<Models.Blog>(blog);
            await _context.Blogs.AddAsync(blogDto);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
            { 
                return null;
            }
            return _mapper.Map<IBlogRepositoryCreateOneBlogAsyncResponse>(blogDto);
        }

        public async Task<IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse?> GetOneBlogWithBlogIdAsync(IBlogRepositoryGetOneBlogWithBlogIdAsyncRequest blog)
        {
            Models.Blog? blogInDb = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blog.Id);
            if (blogInDb is null)
            {
                return null;    
            }
            return _mapper.Map<IBlogRepositoryGetOneBlogWithBlogIdAsyncResponse>(blogInDb);
        }

        public async Task<List<IBlogRepositoryGetAllBlogAsyncResponse>?> GetAllBlogAsync()
        {
            List<Models.Blog> blogsInDb = await _context.Blogs.ToListAsync();
            if (blogsInDb.Count <= 0)
            {
                return null;
            }
            return _mapper.Map<List<IBlogRepositoryGetAllBlogAsyncResponse>>(blogsInDb);
        }



        public async Task<IBlogRepositoryUpdateOneBlogAsyncResponse?> UpdateOneBlogAsync(IBlogRepositoryUpdateOneBlogAsyncRequest blog)
        {
            Models.Blog? blogInDb = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blog.Id);
            if (blogInDb is null)
            {
                return null;
            }
            blogInDb.Title = blog.Title;
            blogInDb.Content = blog.Content;
            blogInDb.WriterId = blog.WriterId;
            _context.Blogs.Update(blogInDb);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<IBlogRepositoryUpdateOneBlogAsyncResponse>(blogInDb);
        }

        public async Task<bool> DeleteOneBlogAsync(IBlogRepositoryDeleteOneBlogAsyncRequest blog)
        {
            //Daha sonralarında safe delete kullanalım
            Models.Blog? blogInDb = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blog.Id);
            if (blogInDb is null)
            {
                return false;
            }
            _context.Blogs.Remove(blogInDb);
            int result =  await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return false;
            }
            return true;
        }

    }
}
