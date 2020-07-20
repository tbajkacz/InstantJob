using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class JobIsNotCompletedRule : IDomainRule
    {
        private readonly JobStatus status;

        public JobIsNotCompletedRule(JobStatus status)
        {
            this.status = status;
        }

        public string Message => "This job was already completed";

        public bool IsViolated() => status.IsCompleted;
    }
}
