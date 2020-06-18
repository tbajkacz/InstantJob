﻿using InstantJob.Core.Jobs.Entities;
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
