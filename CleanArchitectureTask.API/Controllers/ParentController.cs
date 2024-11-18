using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.Interfaces.Services;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.Commons;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetByIdParent;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetParentWithWallet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTask.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ParentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMailService _mailService;
        public ParentController(IMediator mediator,IMailService mailService) { _mediator = mediator; _mailService = mailService; }
        [HttpPost("CreateParent")]
        public async Task<IActionResult> CreateParent(CreateParentRequest request)
        {
            var result = await _mediator.Send(request);
            if( result == null )
            {
                return Ok(Result<ParentResponseCommand>.Success(result));
            }
            return Ok(Result<ParentResponseCommand>.Success(result,$"Parent Added,Successfully"));
        }
        [HttpPost("UpdateParent")]
        public async Task<IActionResult> UpdateParent(UpdateParentRequest request)
        {
            var result = await _mediator.Send(request);
            if( result == null )
            {
                return Ok(Result<ParentResponseCommand>.Success(result));
            }
            return Ok(Result<ParentResponseCommand>.Success(result,$"Parent Updated,Successfully"));
        }
        [HttpPost("DeleteParent")]
        public async Task<IActionResult> DeleteParent(DeleteParentRequest request)
        {
            var result = await _mediator.Send(request);
            if( result == null )
            {
                return Ok(Result<ParentResponseCommand>.Success(result));
            }
            return Ok(Result<ParentResponseCommand>.Success(result,$"Parent Deleted,Successfully"));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentById(int id)
        {
            var query = new GetByIdParentRequest() { ParentId = id };
            var result = await _mediator.Send(query);
            if( result == null )
            {
                return Ok(Result<ParentResponseQuery>.Success($"Not Found Parent With Id {id}"));
            }
            return Ok(Result<ParentResponseQuery>.Success(result));
        }
        [HttpGet("GetParentWithWallet/{id}")]
        public async Task<IActionResult> GetParentWithWalletById(int id)
        {
            var query = new GetParentWithWalletRequest() { ParentId = id };
            var result = await _mediator.Send(query);
            if( result == null )
            {
                return Ok(Result<GetParentWithWalletResponse>.Success($"Not Found Parent With Id {id}"));
            }
            return Ok(Result<GetParentWithWalletResponse>.Success(result));
        }
        [HttpGet("GetAllParent")]
        public async Task<IActionResult> GetAllParent([FromQuery] GetPaginatedParentRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(Result<PaginatedResult<ParentResponseQuery>>.Success(result));
        }


    }
}
