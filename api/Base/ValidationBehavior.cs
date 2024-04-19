using FluentValidation;
using MediatR;

namespace Schoolmanagment.Base;
public  class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{

    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;



    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        var failures = _validators
            .Select(v => v.ValidateAsync(request))
            .SelectMany(result => result.Result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
        {
            
            throw new ValidationException("validation error",failures);
        }

        var response = await next();
        return response;

    }



}
