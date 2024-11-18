using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetByIdParent
{
    public class GetByIdParentHandler : IRequestHandler<GetByIdParentRequest,ParentResponseQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdParentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ParentResponseQuery> Handle(GetByIdParentRequest request,CancellationToken cancellationToken)
        {
            var parent = await _unitOfWork.GetRepository<IParentRepository>().GetById(request.ParentId,cancellationToken);
            if( parent == null )
            {
                throw new NotFoundException($"Parent Not Exist With {request.ParentId}");
            }
            var parentDto = _mapper.Map<ParentResponseQuery>(parent);
            return parentDto;
        }
    }
}