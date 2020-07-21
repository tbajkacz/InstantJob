using System;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using MediatR;

namespace InstantJob.BuildingBlocks.Application.MediatR
{
    public class UnitOfWorkCommitBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork uow;

        public UnitOfWorkCommitBehavior(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
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
