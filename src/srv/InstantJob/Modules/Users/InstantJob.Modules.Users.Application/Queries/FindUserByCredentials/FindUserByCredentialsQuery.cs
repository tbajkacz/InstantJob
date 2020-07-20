using InstantJob.Modules.Users.Domain.Entities;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.FindUserByCredentials
{
    public class FindUserByCredentialsQuery : IRequest<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
