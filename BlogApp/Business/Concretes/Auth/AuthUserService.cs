using AutoMapper;
using BlogApp.Business.Abstracts.Auth;
using BlogApp.Models.Auth;
using BlogApp.Models.Exceptions;
using BlogApp.Models.IAuthUserService;
using BlogApp.Utils.Functions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Business.Concretes.Auth
{
    public class AuthUserService : IAuthUserService
    {


        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AuthUserService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<List<IAuthUserServiceGetAllUsersAsyncResponse>> GetAllUsersAsync()
        {
            List<AppUser> usersInDb = await _userManager.Users.ToListAsync();
            if (usersInDb.Count <= 0)
            {
                //identity exception fırlat(user is not found)
                throw new IdentityException("user is not found");
            }
            return _mapper.Map<List<IAuthUserServiceGetAllUsersAsyncResponse>>(usersInDb);
        }

        public async Task<IAuthUserServiceGetOneUserAsyncResponse> GetOneUserAsync(IAuthUserServiceGetOneUserAsyncRequest user)
        {
            if (CustomNullChecker.nullCheckObjectProps(user))
            { 
                throw new IdentityException("user parameter is null");
            }
            AppUser? foundUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (CustomNullChecker.nullCheckObjectProps(foundUser))
            {
                throw new IdentityException("user is not found");
            }
            return _mapper.Map<IAuthUserServiceGetOneUserAsyncResponse>(foundUser);

        }


        //yeni kayıt
        public async Task<IAuthUserServiceSignInResponse> SignIn(IAuthUserServiceSignInRequest user)
        {
            //null check(daha sonraları kendi null checkimizi kullanacağız)
            if (CustomNullChecker.nullCheckObjectProps(user))
            {
                //identity exception fırlat(user parameter is null)
                throw new IdentityException("user parameter is null");
            }
            AppUser requestForResult = new AppUser()
            {
                UserName = user.UserName,
                Email = user.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(requestForResult, user.Sifre);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(requestForResult,"Writer_CreateWriter");
                return new IAuthUserServiceSignInResponse() { result = true,identityErrors = null};
            }
            else
            {
                //identity exception fırlat(user is not created)
                return new IAuthUserServiceSignInResponse() { result = false, identityErrors = result.Errors };
                throw new IdentityException("user is not created");
            }
            return new IAuthUserServiceSignInResponse() { result = false,identityErrors = null};
        }
        //giriş
        public async Task<bool> Login(IAuthUserServiceLoginRequest user)
        {
            //null check
            if (CustomNullChecker.nullCheckObjectProps(user))
            {
                //identity exception fırlat(user parameter is null)
                return false;
                throw new IdentityException("user parameter is null");

            }
            //useri bulalım
            AppUser? foundUser = await _userManager.FindByEmailAsync(user.Email);
            if (CustomNullChecker.nullCheckObjectProps(foundUser)) 
            {
                //identity exception fırlat(user is not found)
                return false;
                throw new IdentityException("user is not found");

            }
            //İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.
            await _signInManager.SignOutAsync();
            //giriş yapalım
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(foundUser,user.Password,user.Persistent,false);
            
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> DeleteUser(string userName)
        {
            //null check
            if (CustomNullChecker.nullCheckObjectProps(new {userName = userName}))
            {
                //identity exception fırlat(username parameter is null)
                throw new IdentityException("username parameter is null");
            }
            //kullanıcıyı bulalım
            AppUser? foundUser = await _userManager.FindByNameAsync(userName);
            if (CustomNullChecker.nullCheckObjectProps(foundUser))
            {
                //identity exception fırlat(user is not found)
                throw new IdentityException("user is not found");

            }
            foundUser.isDelete = true;
            IdentityResult result = await _userManager.UpdateAsync(foundUser);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> checkUserIsLogin(string userName)
        {
            //null check
            if (CustomNullChecker.nullCheckObjectProps(new { userName = userName }))
            {
                return false;
            }
            AppUser? foundByName = await _userManager.FindByNameAsync(userName);
            if (CustomNullChecker.nullCheckObjectProps(foundByName))
            {
                return false;
            }
            AppUser? foundByEmail = await _userManager.FindByEmailAsync(foundByName.Email);
            if (CustomNullChecker.nullCheckObjectProps(foundByEmail))
            {
                return false;
            }
            AppUser foundAppUser = foundByEmail;
            if (!CustomNullChecker.nullCheckObjectProps(foundAppUser))
            {
                return true;
            }
            return false;

        }
        public async Task<IAuthUserServiceFindLocalUserwithUserNameResponse?> findLocalUserwithUserName(string userName)
        {
            //null check
            if (CustomNullChecker.nullCheckObjectProps(new { userName = userName }))
            {
                return null;
            }
            AppUser? foundByName = await _userManager.FindByNameAsync(userName);
            if (CustomNullChecker.nullCheckObjectProps(foundByName))
            {
                return null;
            }
            return _mapper.Map<IAuthUserServiceFindLocalUserwithUserNameResponse>(foundByName);
        }

        public async Task<Dictionary<string, bool>> checkRoleswithLocalUserName(string userName, List<string> roleNames)
        {
            IAuthUserServiceFindLocalUserwithUserNameResponse? localUser = await findLocalUserwithUserName(userName);
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            if (CustomNullChecker.nullCheckObjectProps(localUser))
            {
                foreach (string role in roleNames)
                {
                    result.Add(role, false);
                }
                return result;
            }
            foreach (string role in roleNames)
            {
                result.Add(role, await _userManager.IsInRoleAsync(_mapper.Map<AppUser>(localUser),role));
            }
            return result;
        }


    }
}
