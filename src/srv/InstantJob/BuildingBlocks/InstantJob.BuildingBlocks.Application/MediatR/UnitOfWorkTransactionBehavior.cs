using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.DomainEvents;
using InstantJob.BuildingBlocks.Application.Interfaces;
using MediatR;

namespace InstantJob.BuildingBlocks.Application.MediatR
{
    public class UnitOfWorkTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IDomainEventsDispatcher dispatcher;

        public UnitOfWorkTransactionBehavior(IUnitOfWork uow, IDomainEventsDispatcher dispatcher)
        {
            this.uow = uow;
            this.dispatcher = dispatcher;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (!uow.Active)
            {
                uow.BeginTransaction();
            }

            var result = await next();

            await dispatcher.DispatchDomainEventsAsync();

            if (uow.Active)
            {
                await uow.CommitAsync();
            }

            return result;
        }
    }
}
