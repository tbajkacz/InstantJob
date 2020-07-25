using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRegistrationRepository registrations;
        private readonly IUserRepository users;

        public CreateUserCommandHandler(IUserRegistrationRepository registrations, IUserRepository users)
        {
            this.registrations = registrations;
            this.users = users;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var registration =
                await registrations.GetByIdAsync(request.UserRegistrationId);

            var user = new User(request.UserRegistrationId, registration.Name,
                registration.Surname, registration.PasswordHash,
                registration.Email, registration.Role);

            await users.AddAsync(user);

            return Unit.Value;
        }
    }
}
