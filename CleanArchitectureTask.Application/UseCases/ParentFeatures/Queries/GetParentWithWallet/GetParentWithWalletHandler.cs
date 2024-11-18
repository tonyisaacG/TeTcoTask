using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Entities;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetParentWithWallet
{
    public class GetParentWithWalletHandler : IRequestHandler<GetParentWithWalletRequest,GetParentWithWalletResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetParentWithWalletHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetParentWithWalletResponse> Handle(GetParentWithWalletRequest request,CancellationToken cancellationToken)
        {
            var parent = await _unitOfWork.GetRepository<IParentRepository>().GetById(request.ParentId,cancellationToken,nameof(Parent.Wallet));
            if( parent == null )
            {
                throw new NotFoundException($"Parent Not Exist With {request.ParentId}");
            }
            var parentDto = _mapper.Map<GetParentWithWalletResponse>(parent);
            return parentDto;
        }
    }
}