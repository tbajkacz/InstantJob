using MediatR;

namespace InstantJob.Core.Users.Commands
{
    public class ChangeUserPasswordCommand : IRequest
    {
        public string Password { get; set; }
    }
}
