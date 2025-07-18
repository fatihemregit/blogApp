using AutoMapper;
using Azure.Core;
using BlogApp.Business.Abstracts.Blog;
using BlogApp.Business.Abstracts.Writer;
using BlogApp.Models.BlogController;
using BlogApp.Models.IBlogService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace BlogApp.Controllers
{

    [Route("/Blog")]
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;
        private readonly IWriterService _writerService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper, IWriterService writerService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _writerService = writerService;
        }

        //Create

        [HttpGet("/Blog/New")]
        public async Task<IActionResult> CreateBlog()
        {

            TempData["writerId"] = await _writerService.GetWriterIdWithAppUserName(User.Identity.Name);
            return View();
        }
        [HttpPost("/Blog/New")]
        public async Task<IActionResult> CreateBlog(CreateBlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBlogServiceCreateOneBlogAsyncRequest request = _mapper.Map<IBlogServiceCreateOneBlogAsyncRequest>(model);
                IBlogServiceCreateOneBlogAsyncResponse response = await _blogService.CreateOneBlogAsync(request);
                //Blog detay a yönlendir(daha sonra)
                return RedirectToAction("GetAllUsers", "AuthUser");
            }
            return View(model);
        }
        //Read
        [HttpGet("/Blog/Read")]
        public async Task<IActionResult> DetailBlog(int blogId = 1)
        {
            IBlogServiceGetOneBlogWithIdAsyncRequest request = new IBlogServiceGetOneBlogWithIdAsyncRequest { Id = blogId };
            IBlogServiceGetOneBlogWithIdAsyncResponse response = await _blogService.GetOneBlogWithIdAsync(request);
            DetailBlogViewModel viewModel = _mapper.Map<DetailBlogViewModel>(response);
            viewModel.WriterName = (await _writerService.GetOneWriterWithIdAsync(new Models.IWriterService.IWriterServiceGetOneWriterWithIdAsyncRequest { Id = response.WriterId })).Name;
            return View(viewModel);
        }
        [HttpGet("/Blog/list")]
        public async Task<IActionResult> ListAllBlogs()
        {
            List<IBlogServiceGetAllBlogAsyncResponse> response = await _blogService.GetAllBlogAsync();
            List<ListAllBlogViewModel> viewModels = _mapper.Map<List<ListAllBlogViewModel>>(response);
            return View(viewModels);
        }


        //Udpdate
        [HttpGet("/Blog/Edit")]
        public async Task<IActionResult> UpdateBlog(int blogId = 1)
        {
            IBlogServiceGetOneBlogWithIdAsyncRequest request = new IBlogServiceGetOneBlogWithIdAsyncRequest { Id = blogId };
            IBlogServiceGetOneBlogWithIdAsyncResponse response = await _blogService.GetOneBlogWithIdAsync(request);
            return View(_mapper.Map<UpdateBlogViewModel>(response));
        }
        [HttpPost("/Blog/Edit")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBlogServiceUpdateOneBlogAsyncRequest request = _mapper.Map<IBlogServiceUpdateOneBlogAsyncRequest>(model);
                IBlogServiceUpdateOneBlogAsyncResponse response = await _blogService.UpdateOneBlogAsync(request);
                return RedirectToAction("DetailBlog", new { blogId = response.Id });
            }
            return View(model);
        }
        //Delete
        [HttpGet("/Blog/Delete")]
        public async Task<IActionResult> DeleteBlog(int blogId = 1)
        {
            IBlogServiceDeleteOneBlogAsyncRequest request = new IBlogServiceDeleteOneBlogAsyncRequest { Id = blogId };
            bool response = await _blogService.DeleteOneBlogAsync(request);
            if (!response)
            {
                return RedirectToAction("AcessDenied", "AuthUser", new { d = "Blog Silme Başarısız" });
            }
            return RedirectToAction("ListAllBlogs");
        }


    }
}
