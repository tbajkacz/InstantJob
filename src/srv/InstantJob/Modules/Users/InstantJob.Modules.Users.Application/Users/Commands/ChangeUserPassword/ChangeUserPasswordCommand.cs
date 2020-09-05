using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest
    {
        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}
