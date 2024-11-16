using CleanArchitectureTask.Application.Commons.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent
{
    public class GetPaginatedParentRequest : PaginatedRequestBase, IRequest<PaginatedResult<GetPaginatedParentResponse>>
    {
    }
}
