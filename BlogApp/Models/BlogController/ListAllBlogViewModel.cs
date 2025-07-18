using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.BlogController
{
    public class ListAllBlogViewModel
    {

        [Display(Name ="Blog Id")]
        public int Id { get; set; }

        [Display(Name = "Blog Başlığı")]
        public string Title { get; set; }
        [Display(Name = "Yazar Id")]
        public int WriterId { get; set; }
    }
}
