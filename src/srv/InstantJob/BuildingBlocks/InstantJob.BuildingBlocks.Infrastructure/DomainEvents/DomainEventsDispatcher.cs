using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.DomainEvents;
using MediatR;

namespace InstantJob.BuildingBlocks.Infrastructure.DomainEvents
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IDomainEventsAccessor accessor;
        private readonly IMediator mediator;

        public DomainEventsDispatcher(IDomainEventsAccessor accessor, IMediator mediator)
        {
            this.accessor = accessor;
            this.mediator = mediator;
        }

        public async Task DispatchDomainEvents()
        {
            var domainEvents = accessor.PopUnhandledDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
