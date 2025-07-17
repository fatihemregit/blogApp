using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.WriterController
{
    public class CreateWriterViewModel
    {
        [Display(Name = "Yazar Adı")]
        [Required(ErrorMessage ="Yazar Adı Alanı Boş Bırakılamaz")]
        public string Name { get; set; }

        [Display(Name = "Yazar Açıklaması")]
        public string? Description { get; set; } = null;

        [Display(Name = "Profil resmi Url")]
        public string? profileUrl { get; set; } = null;

        [Display(Name = "Yazarın Bağlantılı olduğu kullanıcının Id si")]
        public Guid AppUserId { get; set; }
    }
}
