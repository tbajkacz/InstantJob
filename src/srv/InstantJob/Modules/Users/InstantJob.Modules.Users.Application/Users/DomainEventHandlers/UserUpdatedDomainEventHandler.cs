using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Users.Domain.Users.Events;
using InstantJob.Modules.Users.IntegrationEvents;
using MediatR;
using Newtonsoft.Json;

namespace InstantJob.Modules.Users.Application.Users.DomainEventHandlers
{
    public class UserUpdatedDomainEventHandler : INotificationHandler<UserUpdatedDomainEvent>
    {
        private readonly IEventBus eventBus;

        public UserUpdatedDomainEventHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public async Task Handle(UserUpdatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            var integrationEvent = new UserUpdatedIntegrationEvent(
                notification.UserId,
                notification.Name,
                notification.Surname
            );

            await eventBus.PublishAsync(UserUpdatedIntegrationEvent.GetKey(), JsonConvert.SerializeObject(integrationEvent));
        }
    }
}
