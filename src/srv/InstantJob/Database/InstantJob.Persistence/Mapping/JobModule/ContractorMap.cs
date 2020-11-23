using System;
using InstantJob.Modules.Jobs.Domain.Contractors;

namespace InstantJob.Database.Persistence.Mapping.JobModule
{
    internal class ContractorMap : BaseGuidEntityMap<Contractor>
    {
        public ContractorMap()
        {
            References(x => x.JobUser)
                .Cascade.None();
        }
    }
}
