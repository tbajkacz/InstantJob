using InstantJob.Core.Common.Types;
using InstantJob.Core.Users.Entities;
using System;

namespace InstantJob.Core.Jobs.Entities
{
    public class JobApplication : BaseEntity<int>
    {
        public virtual User Contractor { get; set; }

        public virtual DateTime ApplicationDate { get; set; }

        protected JobApplication()
        {

        }

        public JobApplication(User contractor, DateTime applicationDate)
        {
            Contractor = contractor;
            ApplicationDate = applicationDate;
        }

        public JobApplication(User contractor)
            : this(contractor, DateTime.UtcNow)
        {
        }
    }
}
