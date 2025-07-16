namespace BlogApp.Models.Exceptions
{
    public class BlogServiceException:CustomException
    {

        public BlogServiceException(string? message) : base(message,400,500)
        {

        }
    }
}
