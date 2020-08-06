using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Users;
using InstantJob.Modules.Users.IntegrationEvents;

namespace InstantJob.Modules.Jobs.Application.Users.CreateUser
{
    public class UserCreatedIntegrationEventHandler : IIntegrationEventHandler<UserCreatedIntegrationEvent>
    {
        private readonly IUserRepository users;

        public UserCreatedIntegrationEventHandler(IUserRepository users)
        {
            this.users = users;
        }

        public async Task Handle(UserCreatedIntegrationEvent notification,
            CancellationToken cancellationToken)
        {
            var user = new JobUser(notification.UserId, notification.Name, notification.Surname, notification.Email, notification.Role);

            await users.AddAsync(user);
        }
    }
}
