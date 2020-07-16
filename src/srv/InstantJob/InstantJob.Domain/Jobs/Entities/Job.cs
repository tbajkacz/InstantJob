using InstantJob.Domain.Categories.Entities;
using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Rules;
using InstantJob.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.Domain.Jobs.Entities
{
    public class Job : BaseEntity<Guid>
    {
        private readonly IList<JobApplication> applications = new List<JobApplication>();

        public virtual string Title { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual IEnumerable<JobApplication> Applications
        {
            get => applications;
        }

        public virtual decimal Price { get; protected set; }

        public virtual DateTime PostedDate { get; protected set; } = DateTime.UtcNow;

        public virtual DateTime? Deadline { get; protected set; }

        public virtual CompletionInfo CompletionInfo { get; protected set; }

        public virtual Difficulty Difficulty { get; protected set; }

        public virtual Category Category { get; protected set; }

        public virtual User Mandator { get; protected set; }

        public virtual User Contractor { get; protected set; }

        public virtual JobStatus Status { get; protected set; }

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
            CheckRule(new MustBeMandatorRule(mandator));

            Title = title;
            Description = description;
            Price = price;
            Deadline = deadline;
            Difficulty = difficulty;
            Category = category;
            Mandator = mandator;
            Status = JobStatus.Available;
        }

        public virtual void ApplyForJob(User contractor)
        {
            CheckRule(new MustBeContractorRule(contractor));
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new ContractorMustNotHaveTwoActiveApplicationsRule(this, contractor));
            CheckRule(new MustNotBeOwnerOfJobRule(this, contractor));

            applications.Add(new JobApplication(contractor));
        }

        public virtual void WithdrawJobApplication(User contractor)
        {
            CheckRule(new ContractorMustHaveActiveApplicationRule(this, contractor));
            CheckRule(new ContractorMustNotBePerformingJobRule(this, contractor));
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));

            applications.Single(a => a.Contractor.Id == contractor.Id && a.Status.IsActive)
                .WithdrawApplication();
        }

        public virtual void CompleteJob()
        {
            CheckRule(new JobIsInProgressRule(Status));

            CompletionInfo = new CompletionInfo
            {
                CompletionDate = DateTime.UtcNow
            };

            Status = JobStatus.Completed;
        }

        public virtual void AssignContractor(User contractor)
        {
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new ContractorMustHaveActiveApplicationRule(this, contractor));

            Contractor = contractor;
            Status = JobStatus.Assigned;
        }

        public virtual void CancelJobAssignment()
        {
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new JobMustHaveAssignmentRule(Status));

            Contractor = null;
            Status = JobStatus.Available;
        }

        public virtual void UpdateJobDetails(string title, string description, decimal price, DateTime? deadline, Difficulty difficulty)
        {
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new NoContractorAssignedRule(Contractor));

            Title = title;
            Description = description;
            Price = price;
            Deadline = deadline;
            Difficulty = difficulty;
        }

        public virtual void CancelJobOffer()
        {
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));

            Status = JobStatus.Canceled;
        }

        public virtual void AcceptJobAssignment()
        {
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new JobMustHaveAssignmentRule(Status));

            Status = JobStatus.InProgress;
        }

        public virtual bool IsOwnedBy(int mandatorId)
        {
            return mandatorId == Mandator.Id;
        }

        public virtual bool IsAssignedTo(int contractorId)
        {
            return Status.IsAssigned && contractorId == Contractor?.Id;
        }

        public virtual bool IsPerformedBy(int contractorId)
        {
            return Status.IsInProgress && contractorId == Contractor?.Id;
        }

        public virtual bool IsCompletedBy(int contractorId)
        {
            return Status.IsCompleted && contractorId == Contractor?.Id;
        }

        public virtual bool HasActiveApplication(int contractorId)
        {
            return Applications.Any(x => x.Contractor.Id == contractorId && x.Status.IsActive);
        }
    }
}
