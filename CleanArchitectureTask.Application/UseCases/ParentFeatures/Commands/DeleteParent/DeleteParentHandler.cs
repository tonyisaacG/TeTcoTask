using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons;
using CleanArchitectureTask.Domain.Entities;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed class DeleteParentHandler : IRequestHandler<DeleteParentRequest,ParentResponseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteParentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ParentResponseCommand> Handle(DeleteParentRequest request,CancellationToken cancellationToken)
        {
            var parent = await _unitOfWork.GetRepository<IParentRepository>().GetById(request.ParentId,cancellationToken,nameof(Parent.Wallet));
            if( parent == null )
            {
                throw new NotFoundException($"Parent Not Exist With {request.ParentId} To Remove It");
            }
            _unitOfWork.GetRepository<IParentRepository>().Delete(parent);
            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<ParentResponseCommand>(parent);
        }
    }
}
