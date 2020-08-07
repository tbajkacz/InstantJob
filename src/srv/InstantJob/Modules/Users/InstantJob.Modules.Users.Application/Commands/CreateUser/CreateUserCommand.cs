using System;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public Guid UserRegistrationId { get; set; }
    }
}
