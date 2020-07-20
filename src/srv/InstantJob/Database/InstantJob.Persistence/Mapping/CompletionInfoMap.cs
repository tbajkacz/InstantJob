using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Database.Persistence.Mapping
{
    public class CompletionInfoMap : BaseEntityMap<CompletionInfo, int>
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
