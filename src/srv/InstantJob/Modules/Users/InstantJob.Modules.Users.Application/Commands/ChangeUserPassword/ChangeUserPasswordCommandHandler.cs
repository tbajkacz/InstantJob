using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.ChangeUserPassword
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
