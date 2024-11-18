using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed record DeleteParentRequest : IRequest<ParentResponseCommand>
    {
        public int ParentId { get; set; }
    }
}
