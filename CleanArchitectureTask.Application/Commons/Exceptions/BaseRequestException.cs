
namespace CleanArchitectureTask.Application.Commons.Exceptions
{
    public class BaseRequestException : Exception
    {

      
        public BaseRequestException() : base() { }
        public BaseRequestException(string message) : base(message) { }
        public IEnumerable<ValidationResults> ValidationResults { get; set; }
    }
}
