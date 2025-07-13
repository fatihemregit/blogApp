using BlogApp.Models;
using BlogApp.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Context
{
    public class ApplicationDbContext: IdentityDbContext<AppUser,AppRole,Guid>
    {
        //Add-Migration firstmig -Context BlogApp.Data.Context.ApplicationDbContext  -OutputDir "Data//Migrations"

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Writer>()
                .HasOne(w => w.AppUser)
                .WithOne(u => u.Writer)
                .HasForeignKey<Writer>(w => w.AppUserId);
        }

    }
    //Veritabanı bağlantı ve tablo oluşturma işleminin olup olmadığını kontrol etmek için oluşturulan geçici bir sınıf(Daha sonrasında Silinecek)

}
