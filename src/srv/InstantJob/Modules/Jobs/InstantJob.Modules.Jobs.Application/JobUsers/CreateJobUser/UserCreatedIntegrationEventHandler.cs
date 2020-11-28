using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Jobs.Application.JobUsers.Abstractions;
using InstantJob.Modules.Jobs.Domain.JobUsers;

namespace InstantJob.Modules.Jobs.Application.JobUsers.CreateJobUser
{
    public class UserCreatedIntegrationEventHandler : IntegrationEventHandlerBase<UserCreatedMessage>
    {
        private readonly IUserRepository users;

        public UserCreatedIntegrationEventHandler(IUserRepository users)
        {
            this.users = users;
        }

        public override async Task HandleAsync(UserCreatedMessage message)
        {
            var user = new JobUser(message.UserId, message.Name, message.Surname, message.Email, message.Role);

            await users.AddAsync(user);
        }
    }
}
