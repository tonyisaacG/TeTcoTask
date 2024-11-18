using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetByIdParent
{
    public class GetByIdParentValidator : AbstractValidator<GetByIdParentRequest>
    {
        public GetByIdParentValidator()
        {
            RuleFor(x => x.ParentId).GreaterThan(0);
        }
    }
}
