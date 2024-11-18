namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons
{
    public sealed record ParentResponseCommand
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
    }
}
