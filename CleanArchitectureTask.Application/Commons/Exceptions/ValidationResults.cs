namespace CleanArchitectureTask.Application.Commons.Exceptions
{
    public record ValidationResults
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
