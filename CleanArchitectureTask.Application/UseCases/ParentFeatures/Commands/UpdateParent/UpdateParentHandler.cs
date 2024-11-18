using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    public sealed class UpdateParentHandler : IRequestHandler<UpdateParentRequest,ParentResponseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateParentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ParentResponseCommand> Handle(UpdateParentRequest request,CancellationToken cancellationToken)
        {

            var existParent = await _unitOfWork.GetRepository<IParentRepository>().FindParentByNationalIdOrPhoneNum(request.NationalId,request.PhoneNumber);
            if( existParent != null && existParent.Id != request.Id )
            {
                throw new NotFoundException("Can't Create Parent With The Same Phone Or NationalId");
            }
            var oldParent = await _unitOfWork.GetRepository<IParentRepository>().GetById(request.Id,cancellationToken);
            if( oldParent == null )
            {
                throw new NotFoundException($"Parent Not Exist With {request.Id} To Remove It");
            }
            oldParent.PhoneNumber = request.PhoneNumber;
            oldParent.NameEn = request.NameEn;
            oldParent.NameAr = request.NameAr;
            oldParent.Email = request.Email;
            oldParent.NationalId = request.NationalId;

            _unitOfWork.GetRepository<IParentRepository>().Update(oldParent);
            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<ParentResponseCommand>(oldParent);
        }
    }
}
