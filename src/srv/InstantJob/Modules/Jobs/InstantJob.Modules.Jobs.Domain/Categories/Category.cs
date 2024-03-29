﻿using System;
using System.Collections.Generic;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Domain.Categories
{
    public class Category : BaseEntity<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        //TODO consider removing the reference
        public virtual IList<Job> JobsInCategory { get; protected set; }

        protected Category()
        {

        }

        public Category(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
