using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Users.Application.Interfaces;

namespace InstantJob.Web.Api.Services
{
    public class CurrentMandatorService : ICurrentMandatorService
    {
        private readonly ICurrentUserService currentUser;

        public CurrentMandatorService(ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
        }

        public int Id => currentUser.UserId;
    }
}
