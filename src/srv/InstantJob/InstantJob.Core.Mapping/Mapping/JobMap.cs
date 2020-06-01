using InstantJob.Core.Jobs.Entities;
using System;

namespace InstantJob.Core.NHibernate.Mapping
{
    internal class JobMap : BaseEntityMap<Job, Guid>
    {
        public JobMap()
        {
            Map(x => x.Title)
                .Not.Nullable();
            Map(x => x.Description);
            HasMany(x => x.Applications);
            Map(x => x.Price);
            Map(x => x.PostedDate)
                .Not.Nullable();
            Map(x => x.Deadline);
            References(x => x.CompletionInfo);
            Map(x => x.Difficulty);
            Map(x => x.CategoryId);
            Map(x => x.MandatorId)
                .Not.Nullable();
            Map(x => x.MandateeId);
        }
    }
}
