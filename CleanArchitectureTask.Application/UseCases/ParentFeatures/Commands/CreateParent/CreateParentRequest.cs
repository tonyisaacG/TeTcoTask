using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed record CreateParentRequest
        (
            string NameAr,
            string NameEn,
            string NationalId,
            string Email,
            string PhoneNumber
        ) : IRequest<CreateParentResponse>
    {
    }
}
