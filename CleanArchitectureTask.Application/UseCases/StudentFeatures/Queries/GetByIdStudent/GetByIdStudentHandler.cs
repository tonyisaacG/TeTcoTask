using AutoMapper;
using CleanArchitectureTask.Application.Commons.Exceptions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetByIdStudent
{
    public class GetByIdStudentHandler : IRequestHandler<GetByIdStudentRequest,StudentResponseQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdStudentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentResponseQuery> Handle(GetByIdStudentRequest request,CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.GetRepository<IStudentRepository>().GetById(request.StudentId,cancellationToken);
            if( student == null )
            {
                throw new NotFoundException($"Student Not Exist With {request.StudentId}");
            }
            var studentDto = _mapper.Map<StudentResponseQuery>(student);
            return studentDto;
        }
    }
}