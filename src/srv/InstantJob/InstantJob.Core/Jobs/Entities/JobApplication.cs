using InstantJob.Core.Users.Entities;
using SharedKernel.Types;
using System;

namespace InstantJob.Core.Jobs.Entities
{
    public class JobApplication : BaseEntity<int>
    {
        public virtual User Contractor { get; set; }

        public virtual DateTime? ApplicationDate { get; set; }
    }
}
