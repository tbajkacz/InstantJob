using System;
using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Users.Application.UserRegistrations.Command.Abstractions;

namespace InstantJob.Web.Api.Services
{
    public class CurrentContractorService : ICurrentContractorService
    {
        private readonly ICurrentUserService currentUser;

        public CurrentContractorService(ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
        }

        public Guid Id => currentUser.UserId;
    }
}
