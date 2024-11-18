using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.Interfaces.Services;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons;
using CleanArchitectureTask.Domain.Entities;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.CreateStudent
{
    public sealed class CreateStudentHandler : IRequestHandler<CreateStudentRequest,StudentResponseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        public CreateStudentHandler(IUnitOfWork unitOfWork,IMapper mapper,IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailService = mailService;
        }
        public async Task<StudentResponseCommand> Handle(CreateStudentRequest request,CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.CreateTransactionAsync();
                var existStudent = await _unitOfWork.GetRepository<IStudentRepository>().FindStudentByNationalId(request.NationalId);
                if( existStudent != null )
                {
                    throw new NotFoundException("Can't Create Student With The Same NationalId");
                }
                var student = _mapper.Map<Student>(request);
                await _unitOfWork.GetRepository<IStudentRepository>().Create(student);
                await _unitOfWork.SaveAsync(cancellationToken);
                await _unitOfWork.GetRepository<IStudentWalletRepository>().Create(new StudentWallet { OwnerId = student.Id,Balance = request.WalletBalance });
                await _unitOfWork.SaveAsync(cancellationToken);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<StudentResponseCommand>(student);
            }
            catch( Exception ex )
            {
                await _unitOfWork.RollbackAsync();
                throw ex;
            }
        }
    }
}
