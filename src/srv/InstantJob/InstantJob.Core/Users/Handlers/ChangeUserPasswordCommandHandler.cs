using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Users.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Users.Handlers
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand>
    {
        private readonly IUserManager userManager;

        public ChangeUserPasswordCommandHandler(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            await userManager.UpdatePasswordAsync(request);
            return Unit.Value;
        }
    }
}
