using InstantJob.Core.Common.Types;
using System;

namespace InstantJob.Core.Jobs.Entities
{
    public class CompletionInfo : BaseEntity<int>
    {
        public virtual DateTime? CompletionDate { get; set; }

        public virtual string Comment { get; set; }

        public virtual int? Rating { get; set; }
    }
}
