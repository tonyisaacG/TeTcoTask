using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.CreateStudent
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.NameAr).NotEmpty().MinimumLength(3).MaximumLength(100)
                .WithMessage("Name In Arabic Is Required.");
            RuleFor(x => x.NameEn).NotEmpty().MinimumLength(3).MaximumLength(50)
                                .WithMessage("Name In English Is Required.");
            RuleFor(x => x.NationalId).NotEmpty().Length(14)
                .WithMessage("National Id must be 14 digits.");
            RuleFor(x => x.WalletBalance).GreaterThanOrEqualTo(0);

        }
    }
}
