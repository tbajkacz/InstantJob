using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class ContractorMustNotBePerformingJobRule : IDomainRule
    {
        private readonly Job job;
        private readonly User contractor;

        public ContractorMustNotBePerformingJobRule(Job job, User contractor)
        {
            this.job = job;
            this.contractor = contractor;
        }

        public string Message => "The contractor can't be in progress with this job";

        public bool IsViolated() => job.IsPerformedBy(contractor.Id);
    }
}
