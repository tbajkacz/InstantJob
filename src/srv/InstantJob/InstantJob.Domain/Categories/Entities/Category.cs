using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Entities;
using System.Collections.Generic;

namespace InstantJob.Domain.Categories.Entities
{
    public class Category : BaseEntity<int>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Job> JobsInCategory { get; set; }

        protected Category()
        {

        }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
