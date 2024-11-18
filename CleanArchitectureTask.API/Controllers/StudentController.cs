using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.Interfaces.Services;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.CreateStudent;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.DeleteStudent;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.UpdateStudent;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.Commons;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetByIdStudent;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetPaginationStudent;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetStudentWithWallet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTask.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMailService _mailService;
        public StudentController(IMediator mediator,IMailService mailService) { _mediator = mediator; _mailService = mailService; }
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
        {
            var result = await _mediator.Send(request);
            if( result == null )
            {
                return Ok(Result<StudentResponseCommand>.Success(result));
            }
            return Ok(Result<StudentResponseCommand>.Success(result,$"Student Added,Successfully"));
        }
        [HttpPost("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest request)
        {
            var result = await _mediator.Send(request);
            if( result == null )
            {
                return Ok(Result<StudentResponseCommand>.Success(result));
            }
            return Ok(Result<StudentResponseCommand>.Success(result,$"Student Updated,Successfully"));
        }
        [HttpPost("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(DeleteStudentRequest request)
        {
            var result = await _mediator.Send(request);
            if( result == null )
            {
                return Ok(Result<StudentResponseCommand>.Success(result));
            }
            return Ok(Result<StudentResponseCommand>.Success(result,$"Student Deleted,Successfully"));
        }
        [HttpGet("{id}"), ActionName("StudentById")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var query = new GetByIdStudentRequest() { StudentId = id };
            var result = await _mediator.Send(query);
            if( result == null )
            {
                return Ok(Result<StudentResponseQuery>.Success($"Not Found Student With Id {id}"));
            }
            return Ok(Result<StudentResponseQuery>.Success(result));
        }
        [HttpGet("GetStudentWithWallet/{id}")]
        public async Task<IActionResult> GetStudentWithWallet(int id)
        {
            var query = new GetStudentWithWalletRequest() { StudentId = id };
            var result = await _mediator.Send(query);
            if( result == null )
            {
                return Ok(Result<GetStudentWithWalletResponse>.Success($"Not Found Parent With Id {id}"));
            }
            return Ok(Result<GetStudentWithWalletResponse>.Success(result));
        }
        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent([FromQuery] GetPaginatedStudentRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(Result<PaginatedResult<StudentResponseQuery>>.Success(result));
        }


    }
}
