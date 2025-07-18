using AutoMapper;
using BlogApp.Business.Abstracts.Auth;
using BlogApp.Business.Abstracts.Writer;
using BlogApp.Models.IAuthUserService;
using BlogApp.Models.IWriterService;
using BlogApp.Models.WriterController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using System.Collections.Generic;
using System.Web;

namespace BlogApp.Controllers
{
    [Route("Writer/")]
    public class WriterController : Controller
    {

        private readonly IWriterService _writerService;
        private readonly IAuthUserService _authUserService;
        private readonly IMapper _mapper;

        public WriterController(IWriterService writerService, IAuthUserService authUserService, IMapper mapper)
        {
            _writerService = writerService;
            _authUserService = authUserService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Writer_CreateWriter")]
        [HttpGet("/Writer/Create")]
        //Create
        public async Task<IActionResult> CreateWriter()
        {
            //Yazar kaydı fonksiyonu
            //giriş yapan kullanıcının bilgilerini alalım
            if (User.Identity.Name is null)
            {
                return RedirectToAction("AcessDenied", "AuthUser", new { d = "Yazar Oluşturmak için Giriş Yapınız" });
            }
            IAuthUserServiceFindLocalUserwithUserNameResponse? localUser = await _authUserService.findLocalUserwithUserName(User.Identity.Name);
            if (localUser is null)
            {
                return RedirectToAction("AcessDenied", "AuthUser", new { d = "Lokal Kullanıcı Hatası!" });
            }
            ViewBag.localUserId = localUser.Id;
            Console.WriteLine("(Writer Controller)(GET) writer appUser id : " + ViewBag.localUserId);

            return View();
        }
        [Authorize(Roles = "Writer_CreateWriter")]
        [HttpPost("/Writer/Create")]
        public async Task<IActionResult> CreateWriter(CreateWriterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("(Writer Controller) writer appUser id : " + model.AppUserId);
                IWriterServiceCreateOneWriterAsyncRequest request = _mapper.Map<IWriterServiceCreateOneWriterAsyncRequest>(model);
                IWriterServiceCreateOneWriterAsyncResponse response = await _writerService.CreateOneWriterAsync(request);
                return RedirectToAction("LogoutUser", "AuthUser");
            }
            return View(model);
        }
        [Authorize(Roles = "Writer_GetAllWriters")]
        //Read
        [HttpGet("/Writer/ListWriters")]
        public async Task<IActionResult> GetAllWriters()
        {
            List<IWriterServiceGetAllWriterAsyncResponse> response = await _writerService.GetAllWriterAsync();
            List<GetAllWriterViewModel> viewModels = _mapper.Map<List<GetAllWriterViewModel>>(response);
            return View(viewModels);
        }
        [Authorize(Roles = "Writer_WriterDetail")]
        [HttpGet("/Writer/Detail")]
        public async Task<IActionResult> WriterDetail(int writerId)
        {
            IWriterServiceGetOneWriterWithIdAsyncRequest request = new IWriterServiceGetOneWriterWithIdAsyncRequest { Id = writerId };
            IWriterServiceGetOneWriterWithIdAsyncResponse response = await _writerService.GetOneWriterWithIdAsync(request);
            return View(_mapper.Map<WriterDetailViewModel>(response));
        }

        //Update
        [Authorize(Roles = "Writer_WriterUpdate")]
        [HttpGet("/Writer/Update")]
        public async Task<IActionResult> WriterUpdate(int writerId)
        {
            IWriterServiceGetOneWriterWithIdAsyncResponse  response = await _writerService.GetOneWriterWithIdAsync(new IWriterServiceGetOneWriterWithIdAsyncRequest { Id = writerId});
            return View(_mapper.Map<WriterUpdateViewModel>(response));
        }
        [Authorize(Roles = "Writer_WriterUpdate")]
        [HttpPost("/Writer/Update")]
        public async Task<IActionResult> WriterUpdate(WriterUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                IWriterServiceUpdateOneWriterAsyncRequest request = _mapper.Map<IWriterServiceUpdateOneWriterAsyncRequest>(model);
                IWriterServiceUpdateOneWriterAsyncResponse response = await _writerService.UpdateOneWriterAsync(request);
                return RedirectToAction("WriterDetail",new { writerId = response.Id});
            }
            
            return View(model);
        }

        //Delete
        [Authorize(Roles = "Writer_WriterDelete")]
        [HttpGet("/Writer/Delete")]
        public async Task<IActionResult> WriterDelete(int writerId)
        {
            IWriterServiceDeleteOneWriterAsyncRequest request = new IWriterServiceDeleteOneWriterAsyncRequest { Id = writerId };
            bool response = await _writerService.DeleteOneWriterAsync(request);
            if (!response)
            {
                return RedirectToAction("AcessDenied", "AuthUser", new { d = "Yazar silme başarısız" });
            }
            return RedirectToAction("GetAllWriters");
        }

    }
}
