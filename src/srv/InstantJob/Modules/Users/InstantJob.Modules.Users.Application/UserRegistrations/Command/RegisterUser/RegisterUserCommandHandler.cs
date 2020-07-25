using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IHashService hashService;
        private readonly IUserRegistrationRepository userRegistrations;

        public RegisterUserCommandHandler(IHashService hashService, IUserRegistrationRepository userRegistrations)
        {
            this.hashService = hashService;
            this.userRegistrations = userRegistrations;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registration = new UserRegistration(request.Name,
                request.Surname, request.Email,
                hashService.Hash(request.Password), Enumeration.FromInt<Role>(request.RoleId));

            await userRegistrations.AddAsync(registration);

            return registration.Id;
        }
    }
}
