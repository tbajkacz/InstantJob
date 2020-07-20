using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest
    {
        public string Password { get; set; }
    }
}
