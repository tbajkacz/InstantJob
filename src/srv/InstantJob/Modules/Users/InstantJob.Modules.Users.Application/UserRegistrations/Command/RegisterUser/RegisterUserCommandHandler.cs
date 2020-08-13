using System;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using MediatR;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IHashService hashService;
        private readonly IUserRegistrationRepository registrations;

        public RegisterUserCommandHandler(IHashService hashService, IUserRegistrationRepository registrations)
        {
            this.hashService = hashService;
            this.registrations = registrations;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registration = new UserRegistration(
                Guid.NewGuid(),
                request.Name,
                request.Surname, request.Email,
                hashService.Hash(request.Password), Enumeration.FromInt<Role>(request.RoleId));

            await registrations.AddAsync(registration);

            return registration.Id;
        }
    }
}
