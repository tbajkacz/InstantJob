using InstantJob.Domain.Common;

namespace InstantJob.Domain.Jobs.Rules
{
    public class JobIsNotInProgressRule : IDomainRule
    {
        private readonly bool inProgress;

        public JobIsNotInProgressRule(bool inProgress)
        {
            this.inProgress = inProgress;
        }

        public string Message => "This job is currently in progress";

        public bool IsViolated() => inProgress;
    }
}
