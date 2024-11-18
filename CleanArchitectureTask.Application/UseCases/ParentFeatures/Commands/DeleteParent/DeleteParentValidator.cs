using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public class DeleteParentValidator : AbstractValidator<DeleteParentRequest>
    {
        public DeleteParentValidator()
        {
            RuleFor(x => x.ParentId).GreaterThan(0);
        }
    }
}
