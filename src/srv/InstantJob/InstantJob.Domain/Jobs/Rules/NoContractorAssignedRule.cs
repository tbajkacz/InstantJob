using InstantJob.Domain.Common;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class NoContractorAssignedRule : IDomainRule
    {
        private readonly User contractor;

        public NoContractorAssignedRule(User contractor)
        {
            this.contractor = contractor;
        }

        public string Message => "No contractor should be assigned";

        public bool IsViolated() => contractor != null;
    }
}
