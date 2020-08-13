using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Queries.FindUserByCredentials
{
    public class FindUserByCredentialsQuery : IRequest<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
