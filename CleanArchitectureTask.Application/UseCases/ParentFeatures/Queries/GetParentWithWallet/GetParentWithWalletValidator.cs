using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetParentWithWallet
{
    public class GetParentWithWalletValidator : AbstractValidator<GetParentWithWalletRequest>
    {
        public GetParentWithWalletValidator()
        {
            RuleFor(x => x.ParentId).GreaterThan(0);
        }
    }
}
