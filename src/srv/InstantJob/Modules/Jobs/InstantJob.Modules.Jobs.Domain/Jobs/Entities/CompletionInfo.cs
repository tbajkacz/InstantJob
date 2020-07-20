using System;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Entities
{
    public class CompletionInfo : BaseEntity<int>
    {
        public virtual DateTime? CompletionDate { get; set; }

        public virtual string Comment { get; set; }

        public virtual int? Rating { get; protected set; }

        public CompletionInfo() 
            : this(DateTime.UtcNow, null, null)
        {
        }

        public CompletionInfo(DateTime completionDate, string comment, int? rating)
        {
        }
    }
}
