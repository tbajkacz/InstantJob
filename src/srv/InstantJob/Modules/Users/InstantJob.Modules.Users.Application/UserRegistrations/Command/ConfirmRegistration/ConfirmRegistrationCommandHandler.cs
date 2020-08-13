using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;
using MediatR;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.ConfirmRegistration
{
    public class ConfirmRegistrationCommandHandler : IRequestHandler<ConfirmRegistrationCommand>
    {
        private readonly IUserRegistrationRepository registrations;

        public ConfirmRegistrationCommandHandler(IUserRegistrationRepository registrations)
        {
            this.registrations = registrations;
        }

        public async Task<Unit> Handle(ConfirmRegistrationCommand request,
            CancellationToken cancellationToken)
        {
            var registration = await registrations.GetByIdAsync(request.Id);
            registration.Confirm();

            return Unit.Value;
        }
    }
}
