using System;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Database.Persistence.Mapping.JobModule
{
    internal class CompletionInfoMap : BaseGuidEntityMap<CompletionInfo>
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
