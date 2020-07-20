using System;
using System.Collections.Generic;
using System.Linq;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using NHibernate;

namespace InstantJob.Modules.Jobs.Infrastructure.Data
{
    public class NHibernateJobRepository : NHibernateRepositoryBase<Job, Guid>, IJobRepository
    {
        public NHibernateJobRepository(ISession session)
            : base(session)
        {
        }

        public IEnumerable<Job> Get(int? categoryId, int? skip, int? count)
        {
            var query = session.Query<Job>();
            if (categoryId != null)
            {
                query = query.Where(j => j.Category.Id == categoryId);
            }
            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }
            if (count != null)
            {
                query = query.Take(count.Value);
            }

            return query;
        }
    }
}
