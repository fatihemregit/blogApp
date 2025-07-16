namespace BlogApp.Models.IBlogService
{
    public class IBlogServiceCreateOneBlogAsyncRequest
    {
        public string Title { get; set; }

        public string Content { get; set; }
        public int WriterId { get; set; }
    }

}
