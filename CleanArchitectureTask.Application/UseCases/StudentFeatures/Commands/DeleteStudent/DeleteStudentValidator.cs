using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.DeleteStudent
{
    public class DeleteStudentValidator : AbstractValidator<DeleteStudentRequest>
    {
        public DeleteStudentValidator()
        {
            RuleFor(x => x.StudentId).GreaterThan(0);
        }
    }
}
