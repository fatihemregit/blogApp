using BlogApp.Business.Abstracts.Auth;
using BlogApp.Business.Concretes.Auth;
using BlogApp.Data.Context;
using BlogApp.Models.Auth;
using BlogApp.Utils.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BlogApp.Utils.Extensions
{
    public static class MainExtensions
    {
        //Data Extensions
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MsSqlLocal"))
                );
        }
        //Business Extensions
        public static void setInterfaceConcretesForBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IAuthUserService, AuthUserService>();
            services.AddScoped<IAuthRoleService, AuthRoleService>();
        }


        //Main Extensions
        public static void SetAuthentication(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;//şifrenin kaç haneli olduğu
                options.Password.RequireNonAlphanumeric = true; //Alfanumerik zorunluluğunu kaldırıyoruz.
                options.Password.RequireLowercase = true; //Küçük harf zorunluluğunu kaldırıyoruz.
                options.Password.RequireUppercase = true; //Büyük harf zorunluluğunu kaldırıyoruz.
                options.Password.RequireDigit = true; //0-9 arası sayısal karakter zorunluluğunu kaldırıyoruz.
                options.User.RequireUniqueEmail = true; //Email adreslerini tekilleştiriyoruz.
                options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+"; //Kullanıcı adında geçerli olan karakterleri belirtiyoruz.
            }).AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void ConfigureCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/Login");
                _.Cookie = new CookieBuilder
                {
                    Name = "BlogAppIdentityCookie", //Oluşturulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //Kötü niyetli insanların client-side tarafından Cookie'ye erişmesini engelliyoruz.
                    //Expiration = TimeSpan.FromMinutes(2), //Oluşturulacak Cookie'nin vadesini belirliyoruz.(depcreated olmuş)
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden erişilebilir yapıyoruz.
                };
                _.SlidingExpiration = true; //Expiration süresinin yarısı kadar süre zarfında istekte bulunulursa eğer geri kalan yarısını tekrar sıfırlayarak ilk ayarlanan süreyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromMinutes(15); //CookieBuilder nesnesinde tanımlanan Expiration değerinin varsayılan değerlerle ezilme ihtimaline karşın tekrardan Cookie vadesi burada da belirtiliyor.
                _.AccessDeniedPath = new PathString("/User/AccessDenied");
            }
            );
        }

        //SetAutoMapper
        public static void setAutoMapperForMainLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(MappingProfileForMainLayer).Assembly));
        }
    }
}
