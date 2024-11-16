using AutoMapper;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Entities;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed class CreateParentHandler : IRequestHandler<CreateParentRequest,CreateParentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateParentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateParentResponse> Handle(CreateParentRequest request,CancellationToken cancellationToken)
        {
            var parent = _mapper.Map<Parent>(request);
            await _unitOfWork.GetRepository<IParentRepository>().Create(parent);
            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<CreateParentResponse>(parent);
        }
    }
}
