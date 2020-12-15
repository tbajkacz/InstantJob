using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.DomainEvents;
using MediatR;

namespace InstantJob.BuildingBlocks.Application.MediatR
{
    public class NotificationHandlerDomainEventsDispatcherDecorator<T> : INotificationHandler<T> where T : INotification
    {
        private readonly INotificationHandler<T> decorated;
        private readonly IDomainEventsDispatcher dispatcher;

        public NotificationHandlerDomainEventsDispatcherDecorator(INotificationHandler<T> decorated, IDomainEventsDispatcher dispatcher)
        {
            this.decorated = decorated;
            this.dispatcher = dispatcher;
        }

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            await decorated.Handle(notification, cancellationToken);

            await dispatcher.DispatchDomainEventsAsync();
        }
    }
}
