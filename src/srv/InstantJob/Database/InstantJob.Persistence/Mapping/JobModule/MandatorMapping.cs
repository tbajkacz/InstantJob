﻿using System;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Database.Persistence.Mapping.JobModule
{
    public class MandatorMapping : BaseEntityMap<Mandator, Guid>
    {
        public MandatorMapping()
        {
        }
    }
}
