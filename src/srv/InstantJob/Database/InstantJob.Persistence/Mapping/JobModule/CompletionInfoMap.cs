using System;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Database.Persistence.Mapping.JobModule
{
    public class CompletionInfoMap : BaseEntityMap<CompletionInfo, Guid>
    {
        public CompletionInfoMap()
        {
            Map(x => x.CompletionDate)
                .Not.Nullable();
            Map(x => x.Comment);
            Map(x => x.Rating);
        }
    }
}
