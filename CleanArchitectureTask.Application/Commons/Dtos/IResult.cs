
using CleanArchitectureTask.Application.Commons.Exceptions;

namespace CleanArchitectureTask.Application.Commons.Dtos
{
    public interface IResult<TResponse>
    {
        List<string> Messages { get; set; }
        bool Succeeded { get; set; }
        TResponse Data { get; set; }
        List<ValidationResults> ValidationErrors { get; set; }
        int Code { get; set; }
    }
}
