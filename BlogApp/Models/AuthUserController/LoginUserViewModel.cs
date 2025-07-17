using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.AuthUserController
{
    public class LoginUserViewModel
    {

        [DisplayName("Email Adresi")]
        [Required(ErrorMessage = "Email Adresi Alanı Boş Bırakılamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Adresi Alanına Uygun Bir Değer Giriniz")]
        public string Email { get; set; }



        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool Persistent { get; set; }
    }
}
