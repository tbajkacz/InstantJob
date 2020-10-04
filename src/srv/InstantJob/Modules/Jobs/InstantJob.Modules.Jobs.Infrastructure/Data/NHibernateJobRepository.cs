using System;
using System.Collections.Generic;
using System.Linq;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using InstantJob.Modules.Jobs.Application.Jobs.Queries.GetAvailableJobs;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
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

        public IEnumerable<Job> Get(
            Guid? categoryId,
            Guid? contractorId,
            Guid? mandatorId,
            int? difficultyId,
            string searchString,
            string status,
            bool includeExpired,
            int? skip,
            int? count)
        {
            // TODO ToList() is not optimal, because the query will be executed in memory,
            // NHibernate doesn't want to cooperate without it, replace it with EFC
            IEnumerable<Job> query = session.Query<Job>().ToList();
            if (categoryId != null)
            {
                query = query.Where(j => j.Category.Id == categoryId);
            }
            if (contractorId != null)
            {
                query = query.Where(j => j.Contractor?.Id == contractorId);
            }
            if (mandatorId != null)
            {
                query = query.Where(j => j.Mandator?.Id == mandatorId);
            }
            if (difficultyId != null)
            {
                query = query.Where(j => j.Difficulty.Id == difficultyId);
            }
            if (searchString != null)
            {
                query = query.Where(j => j.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrEmpty(status) && Enumeration.FromString<JobStatusQuery>(status) != null)
            {
                if (status == JobStatusQuery.Any.Name)
                {
                    // No filtering is required
                }
                else
                {
                    query = query.Where(j => j.Status.Name == status);
                }
            }
            else
            {
                query = query.Where(j => j.Status == JobStatus.Available);
            }
            if (!includeExpired)
            {
                query = query.Where(j => !j.HasExpired);
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
