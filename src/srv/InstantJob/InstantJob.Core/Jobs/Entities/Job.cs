using InstantJob.Core.Jobs.Constants;
using InstantJob.Core.Users.Entities;
using SharedKernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.Core.Jobs.Entities
{
    public class Job : BaseEntity<Guid>
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<JobApplication> Applications { get; protected set; } = new List<JobApplication>();

        public virtual decimal Price { get; set; }

        public virtual DateTime PostedDate { get; set; } = DateTime.UtcNow;

        public virtual DateTime? Deadline { get; set; }

        public virtual CompletionInfo CompletionInfo { get; protected set; }

        //might be changed to a class enum
        public virtual Difficulty? Difficulty { get; set; }

        public virtual bool WasCanceled { get; protected set; }

        public virtual Category Category { get; set; }

        public virtual User Mandator { get; set; }

        public virtual User Contractor { get; protected set; }

        //Non persisted properties
        public virtual bool IsCompleted => CompletionInfo != null;

        public virtual bool IsInProgress => Contractor != null;

        public virtual void AddJobApplication(JobApplication jobApplication)
        {
            GuardWasCanceled();
            GuardIsCompleted();

            if (Applications.Any(x => x.Contractor == jobApplication.Contractor))
            {
                throw new InvalidOperationException("Each contractor may apply only once");
            }

            Applications.Add(jobApplication);
        }

        public virtual void CompleteJob()
        {
            GuardWasCanceled();
            GuardIsNotInProgress();

            CompletionInfo = new CompletionInfo
            {
                CompletionDate = DateTime.UtcNow
            };
        }

        public virtual void AssignContractor(User contractor)
        {
            GuardWasCanceled();
            GuardIsNotInProgress();
            GuardIsCompleted();

            if (!Applications.Any(x => x.Contractor.Id == contractor.Id))
            {
                throw new InvalidOperationException("The provided contractor did not apply for this job");
            }

            Contractor = contractor;
        }

        public virtual void Cancel()
        {
            GuardWasCanceled();
            GuardIsNotInProgress();
            GuardIsCompleted();

            WasCanceled = true;
        }

        private void GuardIsCompleted(bool throwCondition = true)
        {
            if (IsCompleted == throwCondition)
            {
                throw new InvalidOperationException("Job applications can't be added to a completed job");
            }
        }

        private void GuardIsNotInProgress(bool throwCondition = true)
        {
            if (!IsInProgress == throwCondition)
            {
                throw new InvalidOperationException("A job offer can't be marked as finished");
            }
        }

        private void GuardWasCanceled(bool throwCondition = true)
        {
            if (WasCanceled == throwCondition)
            {
                throw new InvalidOperationException("This job offer was canceled");
            }
        }
    }
}
