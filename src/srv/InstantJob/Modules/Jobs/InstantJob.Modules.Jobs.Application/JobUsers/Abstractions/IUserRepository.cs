using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.JobUsers;

namespace InstantJob.Modules.Jobs.Application.JobUsers.Abstractions
{
    public interface IUserRepository : IRepository<JobUser, Guid>
    {
    }
}
