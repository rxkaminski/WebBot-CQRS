using FluentValidation;
using MediatR;

namespace WebBotCQRS.PiplineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private IEnumerable<IValidator<TRequest>> validators { get; }

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext<TRequest>(request);

            var errors = validators.Select(v => v.Validate(validationContext))
                .SelectMany(v => v.Errors)
                .Where(e => e != null)
                .ToArray();

            if (errors.Any())
                throw new ValidationException(errors);

            return await next();
        }
    }
}
