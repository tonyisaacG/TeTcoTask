using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetPaginationStudent
{
    public class GetPaginatedStudentValidator : AbstractValidator<GetPaginatedStudentRequest>
    {
        public GetPaginatedStudentValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0).LessThan(101);
        }
    }
}