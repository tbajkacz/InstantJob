using InstantJob.Core.Jobs.Entities;
using System;

namespace InstantJob.Core.Common.Interfaces
{
    public interface IJobRepository : IRepository<Job, Guid>
    {
    }
}
