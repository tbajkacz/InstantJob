using MediatR;

namespace InstantJob.Core.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest
    {
        public string Password { get; set; }
    }
}
