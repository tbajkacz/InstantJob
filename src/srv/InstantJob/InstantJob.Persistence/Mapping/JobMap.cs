using InstantJob.Domain.Jobs.Entities;
using System;

namespace InstantJob.Persistence.Mapping
{
    internal class JobMap : BaseEntityMap<Job, Guid>
    {
        public JobMap()
        {
            Map(x => x.Title)
                .Not.Nullable();
            Map(x => x.Description);
            HasMany(x => x.Applications)
                .Cascade.SaveUpdate();
            Map(x => x.Price);
            Map(x => x.PostedDate)
                .Not.Nullable();
            Map(x => x.Deadline);
            References(x => x.CompletionInfo)
                .Cascade.SaveUpdate();
            Map(x => x.Difficulty)
                .CustomType<int>()
                .Access.CamelCaseField();
            Map(x => x.WasCanceled);
            References(x => x.Category)
                .Cascade.None();
            References(x => x.Mandator)
                .Not.Nullable()
                .Cascade.None();
            References(x => x.Contractor)
                .Cascade.None();
        }
    }
}
