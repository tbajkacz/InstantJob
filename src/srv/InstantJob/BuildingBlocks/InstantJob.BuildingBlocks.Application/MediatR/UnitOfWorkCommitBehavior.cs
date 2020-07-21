using System;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using MediatR;

namespace InstantJob.BuildingBlocks.Application.MediatR
{
    public class UnitOfWorkCommitBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TRequest>
        where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork uow;

        public UnitOfWorkCommitBehavior(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<TRequest> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TRequest> next)
        {
            if (!uow.Active)
            {
                throw new Exception("Unit of work connection is already closed");
            }

            var nextRequest = await next();

            await uow.CommitAsync();

            return nextRequest;
        }
    }
}
