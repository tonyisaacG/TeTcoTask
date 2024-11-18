using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed record UpdateParentRequest
        (
            int Id,
            string NameAr,
            string NameEn,
            string NationalId,
            string Email,
            string PhoneNumber
        ) : IRequest<ParentResponseCommand>
    {
    }
}
