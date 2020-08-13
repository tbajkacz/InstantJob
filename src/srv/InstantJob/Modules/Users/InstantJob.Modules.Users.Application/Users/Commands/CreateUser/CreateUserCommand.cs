using System;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public Guid UserRegistrationId { get; set; }
    }
}
