using System;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Users.Application.Interfaces;

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
