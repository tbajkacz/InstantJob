using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Users.Commands.CreateUser;
using InstantJob.Modules.Users.Domain.UserRegistrations.Events;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.DomainEventHandlers
{
    public class UserRegistrationConfirmedDomainEventHandler : INotificationHandler<UserRegistrationConfirmedDomainEvent>
    {
        private readonly IMediator mediator;

        public UserRegistrationConfirmedDomainEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(UserRegistrationConfirmedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateUserCommand
                {UserRegistrationId = notification.UserRegistrationId}, cancellationToken);
        }
    }
}
