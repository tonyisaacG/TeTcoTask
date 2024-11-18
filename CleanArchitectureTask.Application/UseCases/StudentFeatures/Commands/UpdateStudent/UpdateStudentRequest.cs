using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.UpdateStudent
{
    public sealed record UpdateStudentRequest
        (
            int Id,
            string NameAr,
            string NameEn,
            string NationalId,
            string Email
        ) : IRequest<StudentResponseCommand>
    {
    }
}
