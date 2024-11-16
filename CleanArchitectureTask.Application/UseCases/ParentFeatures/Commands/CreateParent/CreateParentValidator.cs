using FluentValidation;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public class CreateParentValidator : AbstractValidator<CreateParentRequest>
    {
        public CreateParentValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.NameAr).NotEmpty().MinimumLength(3).MaximumLength(100)
                .WithMessage("Name In Arabic Is Required.");
            RuleFor(x => x.NameEn).NotEmpty().MinimumLength(3).MaximumLength(50)
                                .WithMessage("Name In English Is Required.");
            RuleFor(x => x.NationalId).NotEmpty().Length(14)
                .WithMessage("National Id must be 14 digits.");
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(11)
                .Matches("^(011|012|015|010)\\d{8}$")
                .WithMessage("Phone number must be 11 digits and start with 011, 012, 015, or 010.");
        }
    }
}
