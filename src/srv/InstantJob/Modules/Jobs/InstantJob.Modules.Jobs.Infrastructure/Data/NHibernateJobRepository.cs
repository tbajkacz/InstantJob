using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Jobs.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.Infrastructure.Data
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
