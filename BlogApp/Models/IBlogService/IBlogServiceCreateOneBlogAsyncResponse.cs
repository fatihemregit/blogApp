namespace BlogApp.Models.IBlogService
{
    public class IBlogServiceCreateOneBlogAsyncResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public int WriterId { get; set; }
    }

}
