using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetStudentWithWallet
{
    public class GetStudentWithWalletValidator : AbstractValidator<GetStudentWithWalletRequest>
    {
        public GetStudentWithWalletValidator()
        {
            RuleFor(x => x.StudentId).GreaterThan(0);
        }
    }
}
