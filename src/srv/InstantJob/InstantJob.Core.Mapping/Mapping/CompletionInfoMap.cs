using InstantJob.Core.Jobs.Models;

namespace InstantJob.Core.NHibernate.Mapping
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
