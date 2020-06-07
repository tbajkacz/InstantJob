using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Users.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Users.Queries.Handlers
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
