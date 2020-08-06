using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using MediatR;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IHashService hashService;
        private readonly IUserRegistrationRepository registrations;

        public RegisterUserCommandHandler(IHashService hashService, IUserRegistrationRepository registrations)
        {
            this.hashService = hashService;
            this.registrations = registrations;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registration = new UserRegistration(
                await registrations.NextIdAsync(),
                request.Name,
                request.Surname, request.Email,
                hashService.Hash(request.Password), Enumeration.FromInt<Role>(request.RoleId));

            await registrations.AddAsync(registration);

            return registration.Id;
        }
    }
}
