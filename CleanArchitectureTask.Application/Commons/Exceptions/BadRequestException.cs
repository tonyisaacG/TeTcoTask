
namespace CleanArchitectureTask.Application.Commons.Exceptions
{
    public class BadRequestException : BaseRequestException
    {
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(IEnumerable<ValidationResults> validationResults) { ValidationResults = validationResults; }
    }
}
