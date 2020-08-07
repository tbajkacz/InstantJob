using System;
using MediatR;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.ConfirmRegistration
{
    public class ConfirmRegistrationCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
