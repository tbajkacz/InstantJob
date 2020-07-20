using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.UpdateUserInformation
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
