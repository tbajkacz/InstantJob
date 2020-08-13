using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand>
    {
        private readonly IUserRepository users;
        private readonly ICurrentUserService currentUser;
        private readonly IHashService hashService;

        public ChangeUserPasswordCommandHandler(IUserRepository users, ICurrentUserService currentUser, IHashService hashService)
        {
            this.users = users;
            this.currentUser = currentUser;
            this.hashService = hashService;
        }

        public async Task<Unit> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await users.GetByIdAsync(currentUser.UserId);

            user.UpdatePassword(hashService.Hash(request.Password));
            await users.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
