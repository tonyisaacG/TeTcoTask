namespace CleanArchitectureTask.Application.Commons.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string[] errors) : base("Multiple errors occurred.") { }
        public string[] Errors { get; set; }
    }
}
