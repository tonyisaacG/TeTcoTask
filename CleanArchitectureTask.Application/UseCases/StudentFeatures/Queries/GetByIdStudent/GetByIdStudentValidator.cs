using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetByIdStudent
{
    public class GetByIdStudentValidator : AbstractValidator<GetByIdStudentRequest>
    {
        public GetByIdStudentValidator()
        {
            RuleFor(x => x.StudentId).GreaterThan(0);
        }
    }
}
