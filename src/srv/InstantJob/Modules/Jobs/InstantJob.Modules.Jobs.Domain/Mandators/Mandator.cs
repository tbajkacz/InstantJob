﻿using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Mandators
{
    public class Mandator : BaseEntity<int>
    {
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual int? Age { get; set; }

        public virtual string Email { get; set; }
    }
}