namespace CleanArchitectureTask.Application.Commons.Exceptions
{
    public class NotFoundException : BaseRequestException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
