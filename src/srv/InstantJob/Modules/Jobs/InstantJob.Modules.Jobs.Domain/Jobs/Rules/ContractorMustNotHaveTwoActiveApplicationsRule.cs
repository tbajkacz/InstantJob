using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class ContractorMustNotHaveTwoActiveApplicationsRule : IDomainRule
    {
        private readonly Job job;
        private readonly Contractor contractor;

        public ContractorMustNotHaveTwoActiveApplicationsRule(Job job, Contractor contractor)
        {
            this.job = job;
            this.contractor = contractor;
        }

        public string Message => "Each contractor may apply only once";

        public bool IsViolated() => job.HasActiveApplication(contractor.Id);
    }
}
