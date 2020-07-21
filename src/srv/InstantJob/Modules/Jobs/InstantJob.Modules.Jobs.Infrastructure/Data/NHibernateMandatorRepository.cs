using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Mandators;
using NHibernate;

namespace InstantJob.Modules.Jobs.Infrastructure.Data
{
    public class NHibernateMandatorRepository : NHibernateRepositoryBase<Mandator, int>, IMandatorRepository
    {
        public NHibernateMandatorRepository(ISession session)
            : base(session)
        {
        }
    }
}
