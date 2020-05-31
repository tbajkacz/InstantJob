using InstantJob.Core.Constants;
using SharedKernel.Types;
using System;
using System.Collections.Generic;

namespace InstantJob.Core.Jobs.Models
{
    public class Job : BaseEntity<Guid>
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<JobApplication> Applications { get; set; } = new List<JobApplication>();

        public virtual decimal Price { get; set; }

        public virtual DateTime PostedDate { get; set; }

        public virtual DateTime Deadline { get; set; }

        public virtual CompletionInfo CompletionInfo { get; set; }

        public virtual Difficulty? Difficulty { get; set; }

        public virtual int? CategoryId { get; set; }

        public virtual int? MandatorId { get; set; }

        public virtual int? MandateeId { get; protected set; }

        //Non persisted properties
        public virtual bool IsCompleted { get; set; }

        public virtual bool Expired { get; set; }
    }
}
