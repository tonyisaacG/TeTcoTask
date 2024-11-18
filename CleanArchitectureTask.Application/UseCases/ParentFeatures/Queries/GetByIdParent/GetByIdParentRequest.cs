using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetByIdParent
{
    public class GetByIdParentRequest : IRequest<ParentResponseQuery>
    {
        public int ParentId { get; set; }
    }
}
