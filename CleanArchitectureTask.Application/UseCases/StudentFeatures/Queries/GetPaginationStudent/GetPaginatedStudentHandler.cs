using AutoMapper;
using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.Commons.Extensions;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.Commons;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetPaginationStudent
{
    public class GetPaginatedStudentHandler : IRequestHandler<GetPaginatedStudentRequest,PaginatedResult<StudentResponseQuery>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPaginatedStudentHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<StudentResponseQuery>> Handle(GetPaginatedStudentRequest request,CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.GetRepository<IStudentRepository>().GetPaginatedStudent(request,cancellationToken);
            var studentDtos = _mapper.Map<IEnumerable<StudentResponseQuery>>(students.Items);
            var studentWithPaginated = studentDtos.ToPaginatedList(students.TotalItem,request.PageNumber,request.PageSize);
            return studentWithPaginated;
        }
    }
}
