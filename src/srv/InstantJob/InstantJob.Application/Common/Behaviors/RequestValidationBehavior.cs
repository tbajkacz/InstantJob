using FluentValidation;
using InstantJob.Core.Common.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Common.Behaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext(request);

            var validationFailures = validators
                .Select(v => v.Validate(validationContext))
                .SelectMany(result => result.Errors.Where(f => f != null));

            if (validationFailures.Count() != 0)
            {
                throw new ValidationFailedException(validationFailures);
            }

            return next();
        }
    }
}
