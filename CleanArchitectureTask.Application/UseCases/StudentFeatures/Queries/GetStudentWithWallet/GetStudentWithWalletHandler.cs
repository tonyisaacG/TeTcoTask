using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Entities;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetStudentWithWallet
{
    public class GetStudentWithWalletHandler : IRequestHandler<GetStudentWithWalletRequest,GetStudentWithWalletResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetStudentWithWalletHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetStudentWithWalletResponse> Handle(GetStudentWithWalletRequest request,CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.GetRepository<IStudentRepository>().GetById(request.StudentId,cancellationToken,nameof(Student.Wallet));
            if( student == null )
            {
                throw new NotFoundException($"Student Not Exist With {request.StudentId}");
            }
            var StudentDto = _mapper.Map<GetStudentWithWalletResponse>(student);
            return StudentDto;
        }
    }
}