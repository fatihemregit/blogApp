using AutoMapper;
using BlogApp.Business.Abstracts.Auth;
using BlogApp.Business.Concretes.Auth;
using BlogApp.Models.AuthRoleController;
using BlogApp.Models.AuthUserController;
using BlogApp.Models.IAuthRoleService;
using BlogApp.Models.IAuthUserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [Route("Auth/User/[action]")]
    public class AuthUserController : Controller
    {
        private readonly IAuthUserService _authUserService;
        private readonly IMapper _mapper;

        public AuthUserController(IAuthUserService authUserService, IMapper mapper)
        {
            _authUserService = authUserService;
            _mapper = mapper;
        }

        /*
         * fterm@admin.com:12345678Aa.
         */
        //Create
        [HttpGet("/SignUp")]
        public async Task<IActionResult> CreateUser()
        {
            bool userLoginState = await _authUserService.checkUserIsLogin(User.Identity.Name);
            if (userLoginState)
            {
                return RedirectToAction("AcessDenied", "AuthUser", new { d = "Giriş Yapan Kullanıcı Yeni Kayıt Açamaz!!" });
            }
            return View();

        }
        [HttpPost("/SignUp")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model valid kayıt işlemini yapalım
                IAuthUserServiceSignInRequest request = _mapper.Map<IAuthUserServiceSignInRequest>(model);
                IAuthUserServiceSignInResponse response = await _authUserService.SignIn(request);
                if (!(response.result))
                {
                    if (response.identityErrors is null)
                    {
                        return View(model);
                    }
                    foreach (IdentityError error in response.identityErrors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return View(model);
                }
                IAuthUserServiceFindLocalUserwithUserNameResponse? notLocalUser = await _authUserService.findLocalUserwithUserName(model.UserName);
                return RedirectToAction("UserDetail", new { userId = notLocalUser.Id.ToString() });
            }
            return View("UserDetail", new { });
        }

        //Read
        [Authorize(Roles ="AuthUser_GetAllUsers")]
        [HttpGet("/Auth/User/ListUsers")]
        public async Task<IActionResult> GetAllUsers()
        {

            bool userLoginState = await _authUserService.checkUserIsLogin(User.Identity.Name);
            TempData["localUserName"] = userLoginState ? User.Identity.Name : "";

            List<IAuthUserServiceGetAllUsersAsyncResponse> response = await _authUserService.GetAllUsersAsync();
            List<GetAllUserViewModel> userInDb = _mapper.Map<List<GetAllUserViewModel>>(response);
            return View(userInDb);
        }
        [Authorize(Roles = "AuthUser_UserDetail")]
        [HttpGet("/Auth/User/DetailUser")]
        public async Task<IActionResult> UserDetail(string userId)
        {
            IAuthUserServiceGetOneUserAsyncRequest request = new IAuthUserServiceGetOneUserAsyncRequest()
            {
                Id = new Guid(userId),
            };
            IAuthUserServiceGetOneUserAsyncResponse response = await _authUserService.GetOneUserAsync(request);

            return View(_mapper.Map<UserDetailViewModel>(response));
        }


        //Delete
        [Authorize(Roles = "AuthUser_DeleteUser")]
        [HttpGet("/Auth/User/DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            bool response = await _authUserService.DeleteUser(userName);
            if (!response)
            {
                return RedirectToAction("AcessDenied", "AuthUser", new { d = "Kullanıcı Silme Başarısız" });

            }
            return RedirectToAction("GetAllUsers");
        }


        //Other
        [HttpGet("/Login/")]
        public async Task<IActionResult> LoginUser(string? ReturnUrl)
        {

            bool userLoginState = await _authUserService.checkUserIsLogin(User.Identity.Name);
            if (userLoginState)
            {
                return RedirectToAction("AcessDenied", "AuthUser", new { d = "Giriş Yapan Kullanıcı Yeniden oturum Açamaz!!" });
            }
            if (ReturnUrl is null)
            {
                ReturnUrl = "/";
            }
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost("/Login/")]
        public async Task<IActionResult> LoginUser(LoginUserViewModel model, string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("redirect url is " + ReturnUrl);
                //model valid gerekli işlemleri yapalım
                IAuthUserServiceLoginRequest request = _mapper.Map<IAuthUserServiceLoginRequest>(model);
                bool response = await _authUserService.Login(request);
                if (!response)
                {
                    ModelState.AddModelError("loginError", "Kullanıcı Adı Veya parola yanlış");
                    return View(model);
                }
                return Redirect(ReturnUrl);
            }
            return Redirect(ReturnUrl);
        }
        [HttpGet("/Logout")]
        public async Task<IActionResult> LogoutUser()
        {
            await _authUserService.Logout();
            return RedirectToAction("Index", "Test");
        }


        [HttpGet("{d?}")]
        public IActionResult AcessDenied([FromRoute(Name = "d")] string description = "Yetki Hatası")
        {
            ViewBag.Description = description;
            return View();
        }




    }

    [Route("Auth/Role/[action]")]
    public class AuthRoleController : Controller
    {
        private readonly IAuthRoleService _roleService;
        private readonly IMapper _mapper;

        public AuthRoleController(IAuthRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [Authorize(Roles = "AuthRole_CreateRole")]
        //Create Role
        [HttpGet("/Auth/Role/Create")]
        public async Task<IActionResult> CreateRole()
        {

            return View();
        }
        [Authorize(Roles = "AuthRole_CreateRole")]
        [HttpPost("/Auth/Role/Create")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model valid gerekli işlemleri yapalım
                IAuthRoleServiceCreateRolePostRequest request = new IAuthRoleServiceCreateRolePostRequest() { Name = model.Name };
                bool response = await _roleService.CreateRolePost(request);
                if (!response)
                {
                    return RedirectToAction("AcessDenied,", "AuthUser", new { d = "Rol Oluşturma başarısız" });
                }
                return RedirectToAction("GetAllUsers", "AuthUser");
            }
            return View();
        }
        //Delete Role
        [Authorize(Roles = "AuthRole_DeleteRole")]
        [HttpGet("/Auth/Role/Delete")]
        public async Task<IActionResult> DeleteRole()
        {
            List<IAuthRoleServiceGetAllRolesAsync> response = await _roleService.DeleteRoleGet();
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> RoleNames = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (IAuthRoleServiceGetAllRolesAsync item in response)
            {
                RoleNames.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.RoleNames = RoleNames;
            return View();
        }
        [Authorize(Roles = "AuthRole_DeleteRole")]
        [HttpPost("/Auth/Role/Delete")]
        public async Task<IActionResult> DeleteRole(DeleteRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Model Valid Gerekli işlemleri yapalım
                IAuthRoleServiceDeleteRolePostRequest request = new IAuthRoleServiceDeleteRolePostRequest { SelectedRoleId = model.Id.ToString() };
                bool response = await _roleService.DeleteRolePost(request);
                if (!response)
                {
                    return RedirectToAction("AcessDenied,", "AuthUser", new { d = "Rol Silme başarısız" });
                }
                return RedirectToAction("GetAllUsers", "AuthUser");
            }
            return View();
        }

        //set Role To User
        [Authorize(Roles = "AuthRole_SetRole")]
        [HttpGet("/Auth/Role/SetRoleForUser")]
        public async Task<IActionResult> SetRole(string userEmail = null)
        {

            List<IAuthRoleServiceSetRoleForUserGet> response = await _roleService.SetRoleForUserGet(userEmail);
            List<SetRoleViewModel> viewModels = _mapper.Map<List<SetRoleViewModel>>(response);
            TempData["userEmail"] = userEmail;
            return View(viewModels);
        
        }
        [Authorize(Roles = "AuthRole_SetRole")]
        [HttpPost("/Auth/Role/SetRoleForUser")]
        public async Task<IActionResult> SetRole(List<SetRoleViewModel> model, string userEmail = null)
        {
            if (ModelState.IsValid)
            {
                List<IAuthRoleServiceSetRoleForUserPost> request = _mapper.Map<List<IAuthRoleServiceSetRoleForUserPost>>(model);
                bool response = await _roleService.SetRoleForUserPost(request, userEmail, User.Identity.Name);
                if (!response)
                {
                    return RedirectToAction("AcessDenied,", "AuthUser", new { d = "Rol Atama başarısız" });
                }
                return RedirectToAction("GetAllUsers", "AuthUser");
            }
            return View(model);
        }

    }

}
