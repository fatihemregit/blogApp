using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.AuthRoleController
{
    public class CreateRoleViewModel
    {
        [DisplayName("Rol İsmi")]
        [Required(ErrorMessage ="Rol İsmi Alanı Boş Bırakılamaz")]
        public string Name { get; set; }

    }
}
