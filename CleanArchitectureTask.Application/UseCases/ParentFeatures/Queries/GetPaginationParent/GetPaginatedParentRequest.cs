using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent
{
    public class GetPaginatedParentRequest : PaginatedRequestBase, IRequest<PaginatedResult<ParentResponseQuery>>
    {
    }
}
