using InstantJob.Domain.Common;
using InstantJob.Domain.Users.Constants;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class MustBeContractorRule : IDomainRule
    {
        private readonly User user;

        public MustBeContractorRule(User user)
        {
            this.user = user;
        }

        public string Message => $"User must be a contractor to perform this action";

        public bool IsViolated() => !user.Roles.Contains(Roles.Contractor);
    }
}
