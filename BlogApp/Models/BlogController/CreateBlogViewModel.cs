using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.BlogController
{
    public class CreateBlogViewModel
    {
        [Display(Name ="Blog Başlığı")]
        public string Title { get; set; }

        [Display(Name = "Yazı İçeriği")]
        public string Content { get; set; }

        [Display(Name  = "Yazar Id")]
        public int WriterId { get; set; }
    }
}
