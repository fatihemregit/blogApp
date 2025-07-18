using BlogApp.Models.Auth;

namespace BlogApp.Models
{
    //Yazar
    public class Writer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string profileUrl { get; set; }

        public bool isDelete { get; set; } = false;


        // Navigation: One writer has many blogs
        public List<Blog> Blogs { get; set; }

        // Foreign Key for AppUser (One-to-One)
        public Guid AppUserId { get; set; }

        // Navigation Property
        public AppUser AppUser { get; set; }

    }
}
