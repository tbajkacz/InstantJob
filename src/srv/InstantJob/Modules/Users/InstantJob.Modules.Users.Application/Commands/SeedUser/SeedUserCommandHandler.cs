using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.SeedUser
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
                await registrations.NextIdAsync(),
                request.Name,
                request.Surname, request.Email,
                hashService.Hash(request.Password), request.Role);

            await registrations.AddAsync(registration);

            registration.Confirm();

            return Unit.Value;
        }
    }
}
