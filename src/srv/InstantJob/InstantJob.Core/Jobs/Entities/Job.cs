using InstantJob.Core.Common.Types;
using InstantJob.Core.Jobs.Constants;
using InstantJob.Core.Jobs.Rules;
using InstantJob.Core.Users.Constants;
using InstantJob.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.Core.Jobs.Entities
{
    public class Job : BaseEntity<Guid>
    {
        public virtual string Title { get; protected set; }

        public virtual string Description { get; protected set; }

        //TODO probably should be an IReadOnlyCollection property with a IList backing field
        public virtual IList<JobApplication> Applications { get; protected set; } = new List<JobApplication>();

        public virtual decimal Price { get; protected set; }

        public virtual DateTime PostedDate { get; protected set; } = DateTime.UtcNow;

        public virtual DateTime? Deadline { get; protected set; }

        public virtual CompletionInfo CompletionInfo { get; protected set; }

        //TODO might be changed to a class enum
        public virtual Difficulty? Difficulty { get; protected set; }

        public virtual bool WasCanceled { get; protected set; }

        public virtual Category Category { get; protected set; }

        public virtual User Mandator { get; protected set; }

        public virtual User Contractor { get; protected set; }

        //Non persisted properties
        public virtual bool IsCompleted => CompletionInfo != null;

        public virtual bool IsInProgress => Contractor != null && CompletionInfo == null;

        protected Job()
        {
        }

        public Job(
            string title,
            string description,
            decimal price,
            DateTime? deadline,
            Difficulty difficulty,
            Category category,
            User mandator)
        {
            if (mandator?.Type != Roles.Mandator)
            {
                throw new InvalidOperationException("Only a mandator is allowed to create jobs");
            }

            Title = title;
            Description = description;
            Price = price;
            Deadline = deadline;
            Difficulty = difficulty;
            Category = category;
            Mandator = mandator;
        }

        public virtual void ApplyForJob(User contractor)
        {
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsNotInProgressRule(IsInProgress));
            CheckRule(new JobIsNotCompletedRule(IsCompleted));

            var jobApplication = new JobApplication(contractor);

            if (Applications.Any(x => x.Contractor == jobApplication.Contractor))
            {
                throw new InvalidOperationException("Each contractor may apply only once");
            }

            Applications.Add(jobApplication);
        }

        public virtual void CompleteJob()
        {
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsInProgressRule(IsInProgress));

            CompletionInfo = new CompletionInfo
            {
                CompletionDate = DateTime.UtcNow
            };
        }

        public virtual void AssignContractor(User contractor)
        {
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsNotInProgressRule(IsInProgress));
            CheckRule(new JobIsNotCompletedRule(IsCompleted));

            if (!Applications.Any(x => x.Contractor.Id == contractor.Id))
            {
                throw new InvalidOperationException("The provided contractor did not apply for this job");
            }

            Contractor = contractor;
        }

        public virtual void UpdateJobDetails(string title, string description, decimal price, DateTime? deadline, Difficulty difficulty)
        {
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsNotInProgressRule(IsInProgress));
            CheckRule(new JobIsNotCompletedRule(IsCompleted));

            Title = title;
            Description = description;
            Price = price;
            Deadline = deadline;
            Difficulty = difficulty;
        }

        public virtual void CancelJobOffer()
        {
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsNotInProgressRule(IsInProgress));
            CheckRule(new JobIsNotCompletedRule(IsCompleted));

            WasCanceled = true;
        }

        public virtual bool WasPostedBy(int mandatorId)
        {
            return mandatorId == Mandator.Id;
        }

        public virtual bool IsAssignedTo(int contractorId)
        {
            return contractorId == Contractor?.Id;
        }
    }
}
