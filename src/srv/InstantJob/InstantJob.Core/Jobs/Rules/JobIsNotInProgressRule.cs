using InstantJob.Core.Common.Interfaces;

namespace InstantJob.Core.Jobs.Rules
{
    public class JobIsNotInProgressRule : IDomainRule
    {
        private readonly bool inProgress;

        public JobIsNotInProgressRule(bool inProgress)
        {
            this.inProgress = inProgress;
        }

        public string Message => "This job is currently in progress";

        public bool IsFailed() => inProgress;
    }
}
