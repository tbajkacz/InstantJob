using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public int UserRegistrationId { get; set; }
    }
}
