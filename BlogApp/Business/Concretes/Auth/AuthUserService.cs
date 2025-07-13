using AutoMapper;
using BlogApp.Business.Abstracts.Auth;
using BlogApp.Models.Auth;
using BlogApp.Models.Exceptions;
using BlogApp.Models.IAuthUserService;
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


        public async Task<List<IAuthUserServiceGetAllUsersAsyncResponse>?> GetAllUsersAsync()
        {
            List<AppUser> usersInDb = await _userManager.Users.ToListAsync();
            if (usersInDb.Count <= 0)
            {
                //identity exception fırlat(user is not found)
                throw new IdentityException("user is not found");
            }
            return _mapper.Map<List<IAuthUserServiceGetAllUsersAsyncResponse>>(usersInDb);
        }

        public async Task<bool> SignIn(IAuthUserServiceSignInRequest user)
        {
            //null check(daha sonraları kendi null checkimizi kullanacağız)
            if (user is null)
            {
                //identity exception fırlat(user parameter is null)
                throw new IdentityException("user parameter is null");
            }
            IdentityResult result = await _userManager.CreateAsync(_mapper.Map<AppUser>(user), user.Sifre);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                //identity exception fırlat(user is not created)
                throw new IdentityException("user is not created");
            }
            return false;
        }
        public async Task<bool> Login(IAuthUserServiceLoginRequest user)
        {
            //null check
            if (user is null)
            {
                //identity exception fırlat(user parameter is null)
                throw new IdentityException("user parameter is null");

            }
            //useri bulalım
            AppUser? foundUser = await _userManager.FindByEmailAsync(user.Email);
            if (foundUser is null) 
            {
                //identity exception fırlat(user is not found)
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
            if (userName is null)
            {
                //identity exception fırlat(username parameter is null)
            }
            //kullanıcıyı bulalım
            AppUser? foundUser = await _userManager.FindByNameAsync(userName);
            if (foundUser is null)
            {
                //identity exception fırlat(user is not found)
                throw new IdentityException("user is not found");

            }
            //kullanıcıyı silelim(daha sonrasında safe delete eklenecek)
            IdentityResult result =  await _userManager.DeleteAsync(foundUser);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> checkUserIsLogin(string userName)
        {
            //null check
            if (userName is null)
            {
                return false;
            }
            AppUser? foundByName = await _userManager.FindByNameAsync(userName);
            if (foundByName is null)
            {
                return false;
            }
            AppUser? foundByEmail = await _userManager.FindByEmailAsync(foundByName.Email);
            if (foundByEmail is null)
            {
                return false;
            }
            AppUser foundAppUser = foundByEmail;
            if (foundAppUser is not null)
            {
                return true;
            }
            return false;

        }
        public async Task<IAuthUserServiceFindLocalUserwithUserNameResponse?> findLocalUserwithUserName(string userName)
        {
            //null check
            if (userName is null)
            {
                return null;
            }
            AppUser? foundByName = await _userManager.FindByNameAsync(userName);
            if (foundByName is null)
            {
                return null;
            }
            return _mapper.Map<IAuthUserServiceFindLocalUserwithUserNameResponse>(foundByName);
        }

        public async Task<Dictionary<string, bool>> checkRoleswithLocalUserName(string userName, List<string> roleNames)
        {
            IAuthUserServiceFindLocalUserwithUserNameResponse? localUser = await findLocalUserwithUserName(userName);
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            if (localUser is null)
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
