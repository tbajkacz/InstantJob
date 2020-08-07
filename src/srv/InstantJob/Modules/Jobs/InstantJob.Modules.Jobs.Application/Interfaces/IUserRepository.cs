using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Users;

namespace InstantJob.Modules.Jobs.Application.Interfaces
{
    public interface IUserRepository : IRepository<JobUser, Guid>
    {
    }
}
