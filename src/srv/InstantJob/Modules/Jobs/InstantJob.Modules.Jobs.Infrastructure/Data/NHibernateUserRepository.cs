using System;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.JobUsers.Abstractions;
using InstantJob.Modules.Jobs.Domain.JobUsers;
using NHibernate;

namespace InstantJob.Modules.Jobs.Infrastructure.Data
{
    public class NHibernateUserRepository : NHibernateRepositoryBase<JobUser, Guid>, IUserRepository
    {
        public NHibernateUserRepository(ISession session)
            : base(session)
        {
        }
    }
}
