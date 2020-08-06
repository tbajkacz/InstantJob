using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Users;
using NHibernate;

namespace InstantJob.Modules.Jobs.Infrastructure.Data
{
    public class NHibernateUserRepository : NHibernateRepositoryBase<JobUser, int>, IUserRepository
    {
        public NHibernateUserRepository(ISession session)
            : base(session)
        {
        }
    }
}
