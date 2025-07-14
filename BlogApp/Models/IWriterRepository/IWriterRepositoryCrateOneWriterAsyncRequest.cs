namespace BlogApp.Models.IWriterRepository
{
    public class IWriterRepositoryCrateOneWriterAsyncRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string profileUrl { get; set; }

        public Guid AppUserId { get; set; }


    }



}
