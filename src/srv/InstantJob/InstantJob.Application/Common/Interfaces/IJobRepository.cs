using InstantJob.Domain.Jobs.Entities;
using System;
using System.Collections.Generic;

namespace InstantJob.Core.Common.Interfaces
{
    public interface IJobRepository : IRepository<Job, Guid>
    {
        IEnumerable<Job> Get(int? categoryId, int? skip, int? count);
    }
}
