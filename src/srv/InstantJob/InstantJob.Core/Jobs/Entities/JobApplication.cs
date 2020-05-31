using SharedKernel.Types;
using System;

namespace InstantJob.Core.Jobs.Entities
{
    public class JobApplication : BaseEntity<int>
    {
        public virtual int? MandateeId { get; set; }

        public virtual DateTime? ApplicationDate { get; set; }
    }
}
