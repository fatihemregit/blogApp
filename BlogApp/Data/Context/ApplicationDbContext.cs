using BlogApp.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Context
{
    public class ApplicationDbContext: IdentityDbContext<AppUser,AppRole,Guid>
    {
        //Add-Migration firstmig -Context BlogApp.Data.Context.ApplicationDbContext  -OutputDir "Data//Migrations"
        public DbSet<TempDb> TempDbs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
    //Veritabanı bağlantı ve tablo oluşturma işleminin olup olmadığını kontrol etmek için oluşturulan geçici bir sınıf(Daha sonrasında Silinecek)
    public class TempDb
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
