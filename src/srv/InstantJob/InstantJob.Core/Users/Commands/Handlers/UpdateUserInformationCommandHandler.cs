using InstantJob.Core.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Users.Commands.Handlers
{
    public class UpdateUserInformationCommandHandler : IRequestHandler<UpdateUserInformationCommand>
    {
        private readonly IUserManager userManager;

        public UpdateUserInformationCommandHandler(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateUserInformationCommand request, CancellationToken cancellationToken)
        {
            await userManager.UpdateInformationAsync(request);
            return Unit.Value;
        }
    }
}
