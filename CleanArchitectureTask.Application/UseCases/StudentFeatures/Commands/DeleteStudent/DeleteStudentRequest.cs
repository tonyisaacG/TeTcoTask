using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.DeleteStudent
{
    public sealed record DeleteStudentRequest : IRequest<StudentResponseCommand>
    {
        public int StudentId { get; set; }
    }
}
