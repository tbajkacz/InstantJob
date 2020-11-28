using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Users.Domain.Users.Events;
using InstantJob.Modules.Users.IntegrationEvents;
using MediatR;
using Newtonsoft.Json;

namespace InstantJob.Modules.Users.Application.Users.DomainEventHandlers
{
    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IEventBus eventBus;

        public UserCreatedDomainEventHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public async Task Handle(UserCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            var integrationEvent = new UserCreatedIntegrationEvent(
                notification.UserId,
                notification.Name,
                notification.Surname,
                notification.Email,
                notification.Role
            );

            await eventBus.PublishAsync(UserCreatedIntegrationEvent.GetKey(), JsonConvert.SerializeObject(integrationEvent));
        }
    }
}
