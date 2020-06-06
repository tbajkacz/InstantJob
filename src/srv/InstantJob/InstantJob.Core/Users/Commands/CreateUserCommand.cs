using MediatR;

namespace InstantJob.Core.Users.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }
    }
}
