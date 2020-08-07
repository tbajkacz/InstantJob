using System;
using MediatR;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.RegisterUser
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
