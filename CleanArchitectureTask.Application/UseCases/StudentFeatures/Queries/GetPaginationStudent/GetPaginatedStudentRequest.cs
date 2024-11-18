using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetPaginationStudent
{
    public class GetPaginatedStudentRequest : PaginatedRequestBase, IRequest<PaginatedResult<StudentResponseQuery>>
    {
    }
}
