using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Domain.Users.Events;
using InstantJob.Modules.Users.IntegrationEvents;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.DomainEventHandlers
{
    public class UserUpdatedDomainEventHandler : INotificationHandler<UserUpdatedDomainEvent>
    {
        private readonly IMediator mediator;

        public UserUpdatedDomainEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(UserUpdatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            var integrationEvent = new UserUpdatedIntegrationEvent(
                notification.UserId,
                notification.Name,
                notification.Surname
            );

            await mediator.Publish(integrationEvent, cancellationToken);
        }
    }
}
