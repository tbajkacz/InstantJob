using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Jobs.Application.JobUsers.Abstractions;
using InstantJob.Modules.Users.IntegrationEvents;

namespace InstantJob.Modules.Jobs.Application.JobUsers.UpdateJobUser
{
    public class UserUpdatedIntegrationEventHandler : IIntegrationEventHandler<UserUpdatedIntegrationEvent>
    {
        private readonly IUserRepository users;

        public UserUpdatedIntegrationEventHandler(IUserRepository users)
        {
            this.users = users;
        }

        public async Task Handle(UserUpdatedIntegrationEvent notification,
            CancellationToken cancellationToken)
        {
            var user = await users.GetByIdAsync(notification.UserId);

            user.UpdateInformation(notification.Name, notification.Surname);

            await users.UpdateAsync(user);
        }
    }
}
