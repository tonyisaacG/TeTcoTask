namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons
{
    public sealed record StudentResponseCommand
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
    }
}
