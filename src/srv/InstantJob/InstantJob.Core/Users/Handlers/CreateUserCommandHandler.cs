using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Users.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserManager userManager;

        public CreateUserCommandHandler(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await userManager.CreateAsync(request);
            return Unit.Value;
        }
    }
}
