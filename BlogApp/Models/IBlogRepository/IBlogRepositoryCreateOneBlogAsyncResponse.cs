namespace BlogApp.Models.IBlogRepository
{
    public class IBlogRepositoryCreateOneBlogAsyncResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public int WriterId { get; set; }
    }


}
