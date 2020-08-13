using System;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using InstantJob.Modules.Users.Application.Users.Abstractions;

namespace InstantJob.Web.Api.Services
{
    public class CurrentMandatorService : ICurrentMandatorService
    {
        private readonly ICurrentUserService currentUser;

        public CurrentMandatorService(ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
        }

        public Guid Id => currentUser.UserId;
    }
}
