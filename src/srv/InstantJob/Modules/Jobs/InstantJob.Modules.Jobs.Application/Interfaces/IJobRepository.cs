using System;
using System.Collections.Generic;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Application.Interfaces
{
    public interface IJobRepository : IRepository<Job, Guid>
    {
        IEnumerable<Job> Get(int? categoryId, int? skip, int? count);
    }
}
