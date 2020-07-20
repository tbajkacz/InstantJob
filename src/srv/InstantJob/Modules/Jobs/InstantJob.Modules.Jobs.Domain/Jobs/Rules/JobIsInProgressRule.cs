using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Constants;

namespace InstantJob.Domain.Jobs.Rules
{
    public class JobIsInProgressRule : IDomainRule
    {
        private readonly JobStatus status;

        public JobIsInProgressRule(JobStatus status)
        {
            this.status = status;
        }

        public string Message => "This job was not started";

        public bool IsViolated() => !status.IsInProgress;
    }
}
