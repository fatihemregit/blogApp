using AutoMapper;
using BlogApp.Business.Abstracts.Auth;
using BlogApp.Models.Auth;
using BlogApp.Models.Exceptions;
using BlogApp.Models.IAuthRoleService;
using BlogApp.Utils.Functions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Business.Concretes.Auth
{
    public class AuthRoleService : IAuthRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;


        public AuthRoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateRolePost(IAuthRoleServiceCreateRolePostRequest role)
        {
            if (CustomNullChecker.nullCheckObjectProps(role))
            {
                //identity exception fırlat(role  parameter is null)
                throw new IdentityException("role  parameter is null");

            }
            IdentityResult result = await _roleManager.CreateAsync(_mapper.Map<AppRole>(role));
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<List<IAuthRoleServiceGetAllRolesAsync>> DeleteRoleGet()
        {
            List<AppRole> rolesInDb = await _roleManager.Roles.ToListAsync();
            //null check
            if (rolesInDb.Count <= 0)
            {
                //identity exception fırlat(role  is not found)
                throw new IdentityException("role  is not found");

            }
            List<IAuthRoleServiceGetAllRolesAsync> roles = _mapper.Map<List<IAuthRoleServiceGetAllRolesAsync>>(rolesInDb);
            return roles;

        }

        public async Task<bool> DeleteRolePost(IAuthRoleServiceDeleteRolePostRequest role)
        {
            //null check
            if (CustomNullChecker.nullCheckObjectProps(role))
            {
                //identity exception fırlat(role parameter is null)
                throw new IdentityException("role parameter is null");

            }
            //rolü id ile bulalım
            AppRole? foundRolewithId = await _roleManager.FindByIdAsync(role.SelectedRoleId);
            if (CustomNullChecker.nullCheckObjectProps(foundRolewithId))
            {
                //identity exception fırlat(role not found)
                throw new IdentityException("role not found");

            }
            //bu rolün aktif olarak kullanılıp kullanılmadığını öğrenelim
            IList<AppUser> getUsersInRole = await _userManager.GetUsersInRoleAsync(foundRolewithId.Name);
            if (getUsersInRole.Count >= 1)
            {
                //identity exception fırlat(role is active)
                throw new IdentityException("role is active");

            }
            //rol aktif olarak kullanılmıyor
            //rol silme
            foundRolewithId.isDelete = true;
            IdentityResult result = await _roleManager.UpdateAsync(foundRolewithId);
            if (result.Succeeded)
            {
                return true;
            }
            return false;


        }

        public async Task<List<IAuthRoleServiceSetRoleForUserGet>> SetRoleForUserGet(string userEmail)
        {
            //null check
            if (CustomNullChecker.nullCheckObjectProps(new { userEmail = userEmail })  )
            {
                //identity exception fırlat(userEmail parameter is null)
                throw new IdentityException("userEmail parameter is null");

            }
            //email ile userı bulalım
            AppUser? foundUserbyEmail = await _userManager.FindByEmailAsync(userEmail);
            if (CustomNullChecker.nullCheckObjectProps(foundUserbyEmail))
            {
                //identity exception fırlat(user not found)
                throw new IdentityException("user not found");

            }
            //sistemdeki tüm rolleri alalım
            List<AppRole> rolesInDb = await _roleManager.Roles.ToListAsync();
            //sistemde hiç rol yoksa rol atama yapamayız
            if (rolesInDb.Count <= 0)
            {
                //identity exception fırlat(does not have any roles in system)
                throw new IdentityException("does not have any roles in system");

            }
            //bulunan kullanıcının tüm rollerini alalım
            IList<string>? foundUserRoles = await _userManager.GetRolesAsync(foundUserbyEmail);
            //bulunan kullanıcının rolleri ile sistemdeki tüm rolleri karşılaştırarak viewde tikli olup olmamasını belirleyelim
            List<IAuthRoleServiceSetRoleForUserGet> setroles = new List<IAuthRoleServiceSetRoleForUserGet>();
            bool foundUserRolesNullState = foundUserRoles is null;
            foreach (AppRole role in rolesInDb)
            {
                setroles.Add(new IAuthRoleServiceSetRoleForUserGet { RoleName = role.Name, State = foundUserRolesNullState ? false: foundUserRoles.Any(s => s == role.Name)});
            }
            return setroles;
        }

        public async Task<bool> SetRoleForUserPost(List<IAuthRoleServiceSetRoleForUserPost> roles, string userEmail, string localUserName)
        {
            //null check
            if ((CustomNullChecker.nullCheckObjectProps(roles)) || CustomNullChecker.nullCheckObjectProps(new {userEmail = userEmail,localUserName = localUserName}) )
            {
                //identity exception fırlat(some parameters are null)
                throw new IdentityException("some parameters are null");

            }
            //kullanıcıyı bulalım
            AppUser? foundUser = await _userManager.FindByEmailAsync(userEmail);
            if (CustomNullChecker.nullCheckObjectProps(foundUser))
            {
                //identity exception fırlat(user not found)
                throw new IdentityException("user not found");

            }
            //role listesine girip rol atama ve silme işlemlerini yapalım
            foreach (IAuthRoleServiceSetRoleForUserPost role in roles)
            {
                if (role.State)
                {
                    //rol ata
                    await _userManager.AddToRoleAsync(foundUser, role.RoleName);
                }
                else
                {
                    //rol sil
                    await _userManager.RemoveFromRoleAsync(foundUser,role.RoleName);
                }
            }
            //rol atama ve silme işlemlerinin geçerli olması için gir çık yapılması gerekli
            //eğer local user ile rol işlemi yapılan kullanıcı aynı ise gir çık yapılsın fakat aynı değil ise herhangi bir şey yapılmasın
            if (foundUser.UserName == localUserName)
            {
                //local user ile rol işlemi yapılan kullanıcı aynı
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(foundUser,true);
            }
            //local user ile rol işlemi yapılan kullanıcı aynı değil
            return true;
        }
    }
}
