namespace BlogApp.Models.IWriterService
{
    public class IWriterServiceCreateOneWriterAsyncRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string profileUrl { get; set; }

        public Guid AppUserId { get; set; }

    }


}
