using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.WriterController
{
    public class WriterUpdateViewModel
    {
        [Display(Name = "Yazar Id")]
        public int Id { get; set; }


        [Display(Name = "Yazar Adı")]
        public string Name { get; set; }

        [Display(Name = "Yazar Açıklaması")]
        public string Description { get; set; }


        [Display(Name = "Profil Resmi")]
        public string profileUrl { get; set; }

        [Display(Name = "Yazarın Bağlantılı olduğu kullanıcının Id si")]
        public Guid AppUserId { get; set; }
    }
}
