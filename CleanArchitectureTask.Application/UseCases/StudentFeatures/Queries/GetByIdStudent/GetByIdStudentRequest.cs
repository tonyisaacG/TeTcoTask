using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetByIdStudent
{
    public class GetByIdStudentRequest : IRequest<StudentResponseQuery>
    {
        public int StudentId { get; set; }
    }
}
