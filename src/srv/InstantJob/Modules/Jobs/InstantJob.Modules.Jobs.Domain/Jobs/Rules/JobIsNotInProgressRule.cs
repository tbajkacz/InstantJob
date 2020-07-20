using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class JobIsNotInProgressRule : IDomainRule
    {
        private readonly JobStatus status;

        public JobIsNotInProgressRule(JobStatus status)
        {
            this.status = status;
        }

        public string Message => "This job is currently in progress";

        public bool IsViolated() => status.IsInProgress;
    }
}
