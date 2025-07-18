namespace BlogApp.Models.BlogController
{
    public class DetailBlogViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public int WriterId { get; set; }

        public string WriterName { get; set; }

    }
}
