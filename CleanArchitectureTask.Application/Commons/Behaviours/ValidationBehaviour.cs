using CleanArchitectureTask.Application.Commons.Exceptions;
using FluentValidation;
using MediatR;

namespace CleanArchitectureTask.Application.Commons.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
        {
            if( !_validators.Any() ) { return await next(); }
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                .Select(obj => obj.Validate(context))
                .SelectMany(obj => obj.Errors)
                .Where(obj => obj != null)
                .DistinctBy(obj => obj.PropertyName)
                .Select(obj => new ValidationResults { PropertyName = obj.PropertyName,ErrorMessage = obj.ErrorMessage });
            if( errors.Any() ) { throw new BadRequestException(errors); }
            return await next();
        }
    }
}
