using System.Linq;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Application.Commands.SeedUser;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Application.UserRegistrations.Command;
using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Infrastructure.Data
{
    public class UserSeeder : IDataSeeder
    {
        private readonly IMediator mediator;
        private readonly IUserRepository userRepository;
        private readonly IUserRegistrationRepository registrations;

        public UserSeeder(IMediator mediator, IUserRepository userRepository, IUserRegistrationRepository registrations)
        {
            this.mediator = mediator;
            this.userRepository = userRepository;
            this.registrations = registrations;
        }
        public async Task SeedAsync()
        {
            await SeedUsers();
        }

        private async Task SeedUsers()
        {
            if (userRepository.Get().Any())
            {
                return;
            }

            var seedCommand = new SeedUserCommand
            {
                Email = "root",
                Name = "root",
                Password = "root",
                Role = Role.Administrator,
                Surname = "root",
            };


            await mediator.Send(seedCommand);
        }
    }
}
