using System.Collections.Generic;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.CreateUser
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
