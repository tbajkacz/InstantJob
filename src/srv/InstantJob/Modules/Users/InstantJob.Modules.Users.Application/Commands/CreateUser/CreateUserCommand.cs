using MediatR;
using System.Collections.Generic;

namespace InstantJob.Core.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IList<string> Roles { get; set; }
    }
}
