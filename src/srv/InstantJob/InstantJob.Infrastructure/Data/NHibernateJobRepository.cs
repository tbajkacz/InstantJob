using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Jobs.Entities;
using NHibernate;
using System;

namespace InstantJob.Infrastructure.Data
{
    public class NHibernateJobRepository : NHibernateRepositoryBase<Job, Guid>, IJobRepository
    {
        public NHibernateJobRepository(ISession session)
            : base(session)
        {
        }
    }
}
