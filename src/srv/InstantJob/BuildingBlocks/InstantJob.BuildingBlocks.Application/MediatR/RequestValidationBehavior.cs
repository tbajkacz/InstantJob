using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using InstantJob.BuildingBlocks.Application.Exceptions;
using MediatR;

namespace InstantJob.BuildingBlocks.Application.MediatR
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
            var validationContext = new ValidationContext<TRequest>(request);

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
