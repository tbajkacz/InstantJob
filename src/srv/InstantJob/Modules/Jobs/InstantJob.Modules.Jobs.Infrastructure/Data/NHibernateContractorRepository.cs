using System;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Contractors;
using NHibernate;

namespace InstantJob.Modules.Jobs.Infrastructure.Data
{
    public class NHibernateContractorRepository : NHibernateRepositoryBase<Contractor, Guid>, IContractorRepository
    {
        public NHibernateContractorRepository(ISession session)
            : base(session)
        {
        }
    }
}
