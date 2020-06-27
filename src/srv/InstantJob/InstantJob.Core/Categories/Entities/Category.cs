using InstantJob.Core.Common.Types;
using InstantJob.Core.Jobs.Entities;
using System.Collections.Generic;

namespace InstantJob.Core.Categories.Entities
{
    public class Category : BaseEntity<int>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Job> JobsInCategory { get; set; }
    }
}
