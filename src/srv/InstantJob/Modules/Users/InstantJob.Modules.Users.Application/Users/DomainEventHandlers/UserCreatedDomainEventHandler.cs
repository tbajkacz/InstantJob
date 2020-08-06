﻿using System.Threading;
using System.Threading.Tasks;
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
            var integrationEvent = new UserCreatedIntegrationEvent(
                notification.UserId,
                notification.Name,
                notification.Surname,
                notification.Email,
                notification.Role
            );

            await mediator.Publish(integrationEvent, cancellationToken);
        }
    }
}
