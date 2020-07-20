using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class MustNotBeOwnerOfJobRule : IDomainRule
    {
        private readonly Job job;
        private readonly User contractor;

        public MustNotBeOwnerOfJobRule(Job job, User contractor)
        {
            this.job = job;
            this.contractor = contractor;
        }

        public string Message => "A mandator may not apply to his own job";

        public bool IsViolated() => job.IsOwnedBy(contractor.Id);
    }
}
