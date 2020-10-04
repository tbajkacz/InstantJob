using System;
using System.Collections.Generic;
using System.Linq;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Categories;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Entities
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

        public virtual Mandator Mandator { get; protected set; }

        public virtual Contractor Contractor { get; protected set; }

        public virtual JobStatus Status { get; protected set; }

        public virtual bool HasExpired => Deadline.HasValue && Deadline.Value <= DateTime.Now;

        protected Job()
        {
        }

        public Job(
            Guid id,
            string title,
            string description,
            decimal price,
            DateTime? deadline,
            Difficulty difficulty,
            Category category,
            Mandator mandator)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Deadline = deadline;
            Difficulty = difficulty;
            Category = category;
            Mandator = mandator;
            Status = JobStatus.Available;
        }

        public virtual void ApplyForJob(Contractor contractor)
        {
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new ContractorMustNotHaveTwoActiveApplicationsRule(this, contractor));

            applications.Add(new JobApplication(contractor));
        }

        public virtual void WithdrawJobApplication(Guid contractorId)
        {
            CheckRule(new ContractorMustHaveActiveApplicationRule(this, contractorId));
            CheckRule(new ContractorMustNotBePerformingJobRule(this, contractorId));
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));

            applications.Single(a => a.Contractor.Id == contractorId && a.Status.IsActive)
                .WithdrawApplication();
        }

        public virtual void CompleteJob(Guid mandatorId)
        {
            CheckRule(new IsJobOwnerRule(this, mandatorId));
            CheckRule(new JobIsInProgressRule(Status));

            CompletionInfo = new CompletionInfo();

            Status = JobStatus.Completed;
        }

        public virtual void AssignContractor(Contractor contractor, Guid mandatorId)
        {
            CheckRule(new IsJobOwnerRule(this, mandatorId));
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new ContractorMustHaveActiveApplicationRule(this, contractor.Id));

            Contractor = contractor;
            Status = JobStatus.Assigned;
        }

        public virtual void CancelJobAssignment(Guid mandatorId)
        {
            CheckRule(new IsJobOwnerRule(this, mandatorId));
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new JobMustHaveAssignmentRule(Status));

            Contractor = null;
            Status = JobStatus.Available;
        }

        public virtual void UpdateJobDetails(string title, string description, decimal price, DateTime? deadline, Difficulty difficulty, Guid mandatorId)
        {
            CheckRule(new IsJobOwnerRule(this, mandatorId));
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

        public virtual void CancelJobOffer(Guid mandatorId)
        {
            CheckRule(new IsJobOwnerRule(this, mandatorId));
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));

            Status = JobStatus.Canceled;
        }

        public virtual void AcceptJobAssignment(Guid contractorId)
        {
            CheckRule(new JobWasNotCanceledRule(Status));
            CheckRule(new JobIsNotInProgressRule(Status));
            CheckRule(new JobIsNotCompletedRule(Status));
            CheckRule(new JobMustHaveAssignmentRule(Status));

            Status = JobStatus.InProgress;
        }

        public virtual bool IsOwnedBy(Guid mandatorId)
        {
            return mandatorId == Mandator.Id;
        }

        public virtual bool IsAssignedTo(Guid contractorId)
        {
            return Status.IsAssigned && contractorId == Contractor?.Id;
        }

        public virtual bool IsPerformedBy(Guid contractorId)
        {
            return Status.IsInProgress && contractorId == Contractor?.Id;
        }

        public virtual bool IsCompletedBy(Guid contractorId)
        {
            return Status.IsCompleted && contractorId == Contractor?.Id;
        }

        public virtual bool HasActiveApplication(Guid contractorId)
        {
            return Applications.Any(x => x.Contractor.Id == contractorId && x.Status.IsActive);
        }
    }
}
