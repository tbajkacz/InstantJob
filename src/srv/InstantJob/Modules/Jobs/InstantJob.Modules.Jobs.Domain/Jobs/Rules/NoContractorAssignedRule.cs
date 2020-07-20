using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Contractors;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class NoContractorAssignedRule : IDomainRule
    {
        private readonly Contractor contractor;

        public NoContractorAssignedRule(Contractor contractor)
        {
            this.contractor = contractor;
        }

        public string Message => "No contractor should be assigned";

        public bool IsViolated() => contractor != null;
    }
}
