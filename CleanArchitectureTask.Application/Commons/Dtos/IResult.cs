using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureTask.Application.Commons.Dtos
{
    public interface IResult<TResponse>
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }

        TResponse Data { get; set; }

        List<ValidationResult> ValidationErrors { get; set; }

        Exception Exception { get; set; }

        int Code { get; set; }
    }
}
