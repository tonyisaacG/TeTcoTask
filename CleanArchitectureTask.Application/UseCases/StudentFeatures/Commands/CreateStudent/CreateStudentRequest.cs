using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.CreateStudent
{
    public sealed record CreateStudentRequest
        (
            string NameAr,
            string NameEn,
            string NationalId,
            string Email,decimal WalletBalance
        ) : IRequest<StudentResponseCommand>
    {
    }
}
