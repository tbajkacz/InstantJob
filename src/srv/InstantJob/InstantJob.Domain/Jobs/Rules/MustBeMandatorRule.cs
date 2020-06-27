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

        public string Message => "Only a mandator is allowed to create jobs";

        public bool IsFailed() => mandator?.Type != Roles.Mandator;
    }
}
