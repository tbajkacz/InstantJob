using SharedKernel.Types;
using System.Collections.Generic;

namespace InstantJob.Core.Jobs.Entities
{
    public class Category : BaseEntity<int>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Job> JobsInCategory { get; set; }
    }
}
