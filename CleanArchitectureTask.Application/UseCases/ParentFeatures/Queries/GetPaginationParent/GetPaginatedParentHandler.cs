using AutoMapper;
using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.Commons.Extensions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent
{
    public class GetPaginatedParentHandler : IRequestHandler<GetPaginatedParentRequest,PaginatedResult<GetPaginatedParentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPaginatedParentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<GetPaginatedParentResponse>> Handle(GetPaginatedParentRequest request,CancellationToken cancellationToken)
        {
            var parents= await _unitOfWork.GetRepository<IParentRepository>().GetPaginatedParent(request,cancellationToken);
            var parentDtos = _mapper.Map<IEnumerable<GetPaginatedParentResponse>>(parents.Items);
            var parentWithPaginated = parentDtos.ToPaginatedList(parents.TotalItem,request.PageNumber,request.PageSize);
            return parentWithPaginated;
        }
    }
}
