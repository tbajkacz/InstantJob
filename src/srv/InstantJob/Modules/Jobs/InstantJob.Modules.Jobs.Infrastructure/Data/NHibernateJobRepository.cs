using System;
using System.Collections.Generic;
using System.Linq;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
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

        public IEnumerable<Job> Get(Guid? categoryId, int? difficultyId, string searchString, int? skip, int? count)
        {
            // TODO ToList() is not optimal, because the query will be executed in memory,
            // NHibernate doesn't want to cooperate without it, replace it with EFC
            IEnumerable<Job> query = session.Query<Job>().ToList();
            if (categoryId != null)
            {
                query = query.Where(j => j.Category.Id == categoryId);
            }
            if (difficultyId != null)
            {
                query = query.Where(j => j.Difficulty.Id == difficultyId);
            }
            if (searchString != null)
            {
                query = query.Where(j => j.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
            }
            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }
            if (count != null)
            {
                query = query.Take(count.Value);
            }

            return query.ToList();
        }
    }
}
