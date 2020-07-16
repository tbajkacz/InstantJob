using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Users.Entities;
using System;

namespace InstantJob.Domain.Jobs.Entities
{
    public class JobApplication : BaseEntity<int>
    {
        public virtual User Contractor { get; protected set; }

        public virtual DateTime ApplicationDate { get; protected set; }

        public virtual ApplicationStatus Status { get; protected set; }

        protected JobApplication()
        {
        }

        public JobApplication(User contractor, DateTime applicationDate, ApplicationStatus status)
        {
            Contractor = contractor;
            ApplicationDate = applicationDate;
            Status = status;
        }

        public JobApplication(User contractor)
            : this(contractor, DateTime.UtcNow, ApplicationStatus.Active)
        {
        }
    }
}
