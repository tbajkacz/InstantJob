using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommandHandler : IRequestHandler<UpdateUserInformationCommand>
    {
        private readonly IUserRepository users;
        private readonly ICurrentUserService currentUser;

        public UpdateUserInformationCommandHandler(IUserRepository users, ICurrentUserService currentUser)
        {
            this.users = users;
            this.currentUser = currentUser;
        }

        public async Task<Unit> Handle(UpdateUserInformationCommand request, CancellationToken cancellationToken)
        {
            var user = await users.GetByIdAsync(currentUser.UserId);

            user.UpdateInformation(request.Name, request.Surname, request.Age, request.Picture);
            await users.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
