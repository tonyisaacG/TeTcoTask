using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.UpdateStudent
{
    public sealed class UpdateStudentHandler : IRequestHandler<UpdateStudentRequest,StudentResponseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateStudentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentResponseCommand> Handle(UpdateStudentRequest request,CancellationToken cancellationToken)
        {
            var existStudent = await _unitOfWork.GetRepository<IStudentRepository>().FindStudentByNationalId(request.NationalId);
            if( existStudent != null && existStudent.Id != request.Id )
            {
                throw new NotFoundException("Can't Create Student With The Same NationalId");
            }
            var oldStudent = await _unitOfWork.GetRepository<IStudentRepository>().GetById(request.Id,cancellationToken);
            if( oldStudent == null )
            {
                throw new NotFoundException($"Student Not Exist With {request.Id} To Remove It");
            }

            oldStudent.NameEn = request.NameEn;
            oldStudent.NameAr = request.NameAr;
            oldStudent.Email = request.Email;
            oldStudent.NationalId = request.NationalId;

            _unitOfWork.GetRepository<IStudentRepository>().Update(oldStudent);
            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<StudentResponseCommand>(oldStudent);
        }
    }
}
