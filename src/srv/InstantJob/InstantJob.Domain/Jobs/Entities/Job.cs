using InstantJob.Domain.Categories.Entities;
using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Rules;
using InstantJob.Domain.Users.Entities;
using System;
using System.Collections.Generic;

namespace InstantJob.Domain.Jobs.Entities
{
    public class Job : BaseEntity<Guid>
    {
        private int difficulty;
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

        public virtual Difficulty Difficulty
        {
            get => (Difficulty)difficulty;
            protected set => difficulty = (int)value;
        }

        public virtual bool WasCanceled { get; protected set; }

        public virtual Category Category { get; protected set; }

        public virtual User Mandator { get; protected set; }

        public virtual User Contractor { get; protected set; }

        public virtual bool HasContractorAcceptedAssignment { get; protected set; }

        //Non persisted properties
        public virtual bool IsCompleted => CompletionInfo != null;

        public virtual bool IsInProgress => Contractor != null && CompletionInfo == null && HasContractorAcceptedAssignment;

        public virtual bool IsAvailable => !WasCanceled && !IsCompleted;

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
        }

        public virtual void ApplyForJob(User contractor)
        {
            CheckRule(new MustBeContractorRule(contractor));
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsNotInProgressRule(IsInProgress));
            CheckRule(new JobIsNotCompletedRule(IsCompleted));
            CheckRule(new ContractorCannotApplyTwiceRule(Applications, contractor.Id));
            CheckRule(new MandatorCannotApplyToHisJobRule(Mandator.Id, contractor.Id));

            applications.Add(new JobApplication(contractor));
        }

        public virtual void CompleteJob()
        {
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
            CheckRule(new ContractorMustHaveAppliedForJobRule(Applications, contractor.Id));

            Contractor = contractor;
        }

        public virtual void UpdateJobDetails(string title, string description, decimal price, DateTime? deadline, Difficulty difficulty)
        {
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsNotInProgressRule(IsInProgress));
            CheckRule(new JobIsNotCompletedRule(IsCompleted));
            CheckRule(new NoContractorAssignedRule(Contractor));

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

        public virtual void AcceptJobAssignment()
        {
            CheckRule(new JobWasNotCanceledRule(WasCanceled));
            CheckRule(new JobIsNotInProgressRule(IsInProgress));
            CheckRule(new JobIsNotCompletedRule(IsCompleted));

            HasContractorAcceptedAssignment = true;
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
