using System;
using System.Collections.Generic;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Application.Jobs.Abstractions
{
    public interface IJobRepository : IRepository<Job, Guid>
    {
        IEnumerable<Job> Get(Guid? categoryId, int? skip, int? count);
    }
}
