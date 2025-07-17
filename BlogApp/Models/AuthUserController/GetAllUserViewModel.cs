using System.ComponentModel;

namespace BlogApp.Models.AuthUserController
{
    public class GetAllUserViewModel
    {
        [DisplayName("User Id")]
        public Guid Id { get; set; }


        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Email Adresi")]
        public string Email { get; set; }
    }
}
