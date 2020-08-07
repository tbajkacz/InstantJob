using System;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Entities
{
    public class CompletionInfo : BaseEntity<Guid>
    {
        public virtual DateTime? CompletionDate { get; set; }

        public virtual string Comment { get; set; }

        public virtual int? Rating { get; protected set; }

        public CompletionInfo() 
            : this(Guid.NewGuid(), DateTime.UtcNow, null, null)
        {
        }

        public CompletionInfo(Guid id, DateTime completionDate, string comment, int? rating)
        {
            Id = id;
            CompletionDate = completionDate;
            Comment = comment;
            Rating = rating;
        }
    }
}
