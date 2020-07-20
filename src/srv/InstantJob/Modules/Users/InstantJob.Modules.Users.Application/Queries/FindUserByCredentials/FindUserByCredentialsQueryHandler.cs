using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Entities;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.FindUserByCredentials
{
    public class FindUserByCredentialsQueryHandler : IRequestHandler<FindUserByCredentialsQuery, User>
    {
        private readonly IUserManager userManager;

        public FindUserByCredentialsQueryHandler(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<User> Handle(FindUserByCredentialsQuery request, CancellationToken cancellationToken)
        {
            return await userManager.ValidateCredentialsAsync(request);
        }
    }
}
