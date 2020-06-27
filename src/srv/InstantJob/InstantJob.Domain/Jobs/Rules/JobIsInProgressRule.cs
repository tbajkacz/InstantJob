using InstantJob.Domain.Common;

namespace InstantJob.Domain.Jobs.Rules
{
    public class JobIsInProgressRule : IDomainRule
    {
        private readonly bool inProgress;

        public JobIsInProgressRule(bool inProgress)
        {
            this.inProgress = inProgress;
        }

        public string Message => "This job was not started";

        public bool IsFailed() => !inProgress;
    }
}
