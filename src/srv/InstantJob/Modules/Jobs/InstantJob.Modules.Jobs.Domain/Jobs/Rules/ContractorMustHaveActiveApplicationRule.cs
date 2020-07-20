using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class ContractorMustHaveActiveApplicationRule : IDomainRule
    {
        private readonly Job job;
        private readonly int contractorId;

        public ContractorMustHaveActiveApplicationRule(Job job, int contractorId)
        {
            this.job = job;
            this.contractorId = contractorId;
        }

        public string Message => "A contractor must first apply, before being assigned to a job";

        public bool IsViolated() => !job.HasActiveApplication(contractorId);
    }
}
