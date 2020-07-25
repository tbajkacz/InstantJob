using MediatR;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.ConfirmRegistration
{
    public class ConfirmRegistrationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
