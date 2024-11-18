

using CleanArchitectureTask.Application.Commons.Exceptions;

namespace CleanArchitectureTask.Application.Commons.Dtos
{

    public class Result<T> : IResult<T>
    {
        public List<string> Messages { get; set; } = new List<string>();
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public List<ValidationResults> ValidationErrors { get; set; }
        public int Code { get; set; }
        public static Result<T> Success(string? message = null)
        {
            return new Result<T>
            {
                Succeeded = true,
                Messages = message == null ? new List<string>() : new List<string> { message },
                Code = 200
            };
        }
        public static Result<T> Success(T data,string? message = null)
        {
            return new Result<T>
            {
                Succeeded = true,
                Messages = new List<string> { message },
                Data = data,
                Code = 200
            };
        }
        public static Result<T> Failure(T data,string message = null)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = new List<string> { message },
                Data = data,
                Code = 400
            };
        }

        public static Result<T> Failure(T data,List<string> messages = null)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = messages,
                Data = data,
                Code = 400
            };
        }
        public static Result<T> Failure(List<string> messages = null)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = messages,
                Code = 400
            };
        }

    }
}
