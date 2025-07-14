namespace BlogApp.Models.IBlogRepository
{
    public class IBlogRepositoryCreateOneBlogAsyncRequest
    {
        public string Title { get; set; }

        public string Content { get; set; }
        public int WriterId { get; set; }

    }


}
