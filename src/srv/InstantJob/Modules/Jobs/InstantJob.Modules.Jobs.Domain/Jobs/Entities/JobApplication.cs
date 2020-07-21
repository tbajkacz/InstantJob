using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Entities
{
    public class JobApplication : BaseEntity<int>
    {
        public virtual Contractor Contractor { get; protected set; }

        public virtual DateTime ApplicationDate { get; protected set; }

        public virtual ApplicationStatus Status { get; protected set; }

        protected JobApplication()
        {
        }

        public JobApplication(Contractor contractor, DateTime applicationDate, ApplicationStatus status)
        {
            Contractor = contractor;
            ApplicationDate = applicationDate;
            Status = status;
        }

        public JobApplication(Contractor contractor)
            : this(contractor, DateTime.UtcNow, ApplicationStatus.Active)
        {
        }

        public virtual void WithdrawApplication()
        {
            Status = ApplicationStatus.Withdrawn;
        }
    }
}
