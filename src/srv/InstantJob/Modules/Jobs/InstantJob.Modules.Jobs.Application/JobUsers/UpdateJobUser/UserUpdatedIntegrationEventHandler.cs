using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Jobs.Application.JobUsers.Abstractions;

namespace InstantJob.Modules.Jobs.Application.JobUsers.UpdateJobUser
{
    public class UserUpdatedIntegrationEventHandler : IntegrationEventHandlerBase<UserUpdatedMessage>
    {
        private readonly IUserRepository users;

        public UserUpdatedIntegrationEventHandler(IUserRepository users)
        {
            this.users = users;
        }

        public override async Task HandleAsync(UserUpdatedMessage message)
        {
            var user = await users.GetByIdAsync(message.UserId);

            user.UpdateInformation(message.Name, message.Surname);

            await users.UpdateAsync(user);
        }
    }
}
