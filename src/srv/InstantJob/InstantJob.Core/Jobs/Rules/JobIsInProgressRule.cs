using InstantJob.Core.Common.Interfaces;

namespace InstantJob.Core.Jobs.Rules
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
