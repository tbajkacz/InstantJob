using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Users.Domain.Users;
using InstantJob.Modules.Users.Domain.Users.Events;
using InstantJob.Modules.Users.IntegrationEvents;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.DomainEventHandlers
{
    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IMediator mediator;

        public UserCreatedDomainEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(UserCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            IIntegrationEvent integrationEvent = notification.Role switch
            {
                _ when notification.Role == Role.Contractor =>
                    new ContractorCreatedIntegrationEvent(
                        notification.UserId,
                        notification.Name,
                        notification.Surname,
                        notification.Email
                        ),
                _ when notification.Role == Role.Mandator => 
                    new MandatorCreatedIntegrationEvent(
                        notification.UserId,
                        notification.Name,
                        notification.Surname,
                        notification.Email
                        ),
                _ => null
            };

            if (integrationEvent != null)
            {
                await mediator.Publish(integrationEvent, cancellationToken);
            }
        }
    }
}
