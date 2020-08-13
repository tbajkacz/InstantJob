using System;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Common.Abstractions;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Commands.SeedUser
{
    public class SeedUserCommandHandler : IRequestHandler<SeedUserCommand>
    {
        private readonly IHashService hashService;
        private readonly IUserRegistrationRepository registrations;

        public SeedUserCommandHandler(IHashService hashService, IUserRegistrationRepository registrations)
        {
            this.hashService = hashService;
            this.registrations = registrations;
        }

        public async Task<Unit> Handle(SeedUserCommand request, CancellationToken cancellationToken)
        {
            var registration = new UserRegistration(
                Guid.NewGuid(),
                request.Name,
                request.Surname, request.Email,
                hashService.Hash(request.Password), request.Role);

            await registrations.AddAsync(registration);

            registration.Confirm();

            return Unit.Value;
        }
    }
}
