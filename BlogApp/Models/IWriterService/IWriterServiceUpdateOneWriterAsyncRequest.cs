namespace BlogApp.Models.IWriterService
{
    public class IWriterServiceUpdateOneWriterAsyncRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string profileUrl { get; set; }
        public Guid AppUserId { get; set; }
    }


}
