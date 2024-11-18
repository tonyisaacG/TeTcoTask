using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.CreateStudent;
using CleanArchitectureTask.Domain.Entities;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.DeleteStudent
{
    public sealed class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest,StudentResponseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteStudentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentResponseCommand> Handle(DeleteStudentRequest request,CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.GetRepository<IStudentRepository>().GetById(request.StudentId,cancellationToken,nameof(Student.Wallet));
            if( student == null )
            {
                throw new NotFoundException($"Student Not Exist With {request.StudentId} To Remove It");
            }
            _unitOfWork.GetRepository<IStudentRepository>().Delete(student);
            await _unitOfWork.SaveAsync(cancellationToken);
            return _mapper.Map<StudentResponseCommand>(student);
        }
    }
}
