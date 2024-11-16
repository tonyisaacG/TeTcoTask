using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureTask.Application.Commons.Dtos
{

    public class Result<T> : IResult<T>
    {
        public List<string> Messages { get; set; } = new List<string>();

        public bool Succeeded { get; set; }

        public T Data { get; set; }

        public List<ValidationResult> ValidationErrors { get; set; }

        public Exception Exception { get; set; }

        public int Code { get; set; }

        public static Result<T> Success()
        {
            return new Result<T>
            {
                Succeeded = true
            };
        }
        public static Result<T> Success(T data,string message)
        {
            return new Result<T>
            {
                Succeeded = true,
                Messages = new List<string> { message },
                Data = data
            };
        }
        public static Result<T> Failure(T data,string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = new List<string> { message },
                Data = data
            };
        }

        public static Result<T> Failure(T data,List<string> messages)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = messages,
                Data = data
            };
        }

    }
}
