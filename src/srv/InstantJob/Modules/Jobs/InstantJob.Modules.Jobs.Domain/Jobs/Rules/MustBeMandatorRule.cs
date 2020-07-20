using InstantJob.Domain.Common;
using InstantJob.Domain.Users.Constants;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class MustBeMandatorRule : IDomainRule
    {
        private readonly User mandator;

        public MustBeMandatorRule(User mandator)
        {
            this.mandator = mandator;
        }

        public string Message => "User must be a mandator to perform this action";

        public bool IsViolated() => !mandator.Roles.Contains(Roles.Mandator);
    }
}
