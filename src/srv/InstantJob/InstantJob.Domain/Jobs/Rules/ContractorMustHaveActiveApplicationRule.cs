using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class ContractorMustHaveActiveApplicationRule : IDomainRule
    {
        private readonly Job job;
        private readonly User contractor;

        public ContractorMustHaveActiveApplicationRule(Job job, User contractor)
        {
            this.job = job;
            this.contractor = contractor;
        }

        public string Message => "A contractor must first apply, before being assigned to a job";

        public bool IsViolated() => !job.HasActiveApplication(contractor.Id);
    }
}
