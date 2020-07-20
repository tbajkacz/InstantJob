using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class ContractorMustNotHaveTwoActiveApplicationsRule : IDomainRule
    {
        private readonly Job job;
        private readonly User contractor;

        public ContractorMustNotHaveTwoActiveApplicationsRule(Job job, User contractor)
        {
            this.job = job;
            this.contractor = contractor;
        }

        public string Message => "Each contractor may apply only once";

        public bool IsViolated() => job.HasActiveApplication(contractor.Id);
    }
}
