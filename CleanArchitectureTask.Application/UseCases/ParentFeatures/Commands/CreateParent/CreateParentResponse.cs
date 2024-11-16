namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed record CreateParentResponse
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
    }
}
