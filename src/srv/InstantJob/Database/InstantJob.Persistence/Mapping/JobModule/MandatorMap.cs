using System;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Database.Persistence.Mapping.JobModule
{
    internal class MandatorMap : BaseEntityMap<Mandator, Guid>
    {
        public MandatorMap()
        {
            References(x => x.JobUser)
                .Cascade.None();
        }
    }
}
