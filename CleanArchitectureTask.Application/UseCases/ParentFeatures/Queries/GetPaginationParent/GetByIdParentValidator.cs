using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent;
using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetByIdParent
{
    public class GetPaginatedParentValidator : AbstractValidator<GetPaginatedParentRequest>
    {
        public GetPaginatedParentValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0).LessThan(101);
        }
    }
}