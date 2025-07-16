namespace BlogApp.Models.Exceptions
{
    public class WriterServiceException : CustomException
    {
        public WriterServiceException(string? message) : base(message, 400, 500)
        {
        }
    }
}
