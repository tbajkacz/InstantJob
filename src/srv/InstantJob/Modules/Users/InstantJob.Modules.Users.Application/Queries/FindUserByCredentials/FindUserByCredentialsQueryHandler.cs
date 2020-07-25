using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.FindUserByCredentials
{
    public class FindUserByCredentialsQueryHandler : IRequestHandler<FindUserByCredentialsQuery, User>
    {
        private readonly IUserRepository users;
        private readonly IHashService hashService;

        public FindUserByCredentialsQueryHandler(IUserRepository users, IHashService hashService)
        {
            this.users = users;
            this.hashService = hashService;
        }

        public async Task<User> Handle(FindUserByCredentialsQuery request, CancellationToken cancellationToken)
        {
            var user = await users.FindByEmailAsync(request.Email);

            return user == null ? null : hashService.CompareHashes(request.Password, user.PasswordHash) ? user : null;
        }
    }
}
