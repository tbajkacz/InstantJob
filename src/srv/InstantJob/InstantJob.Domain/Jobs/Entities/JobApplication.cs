using InstantJob.Domain.Common;
using InstantJob.Domain.Users.Entities;
using System;

namespace InstantJob.Domain.Jobs.Entities
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
