using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Constants;

namespace InstantJob.Domain.Jobs.Rules
{
    public class JobMustHaveAssignmentRule : IDomainRule
    {
        private readonly JobStatus status;

        public JobMustHaveAssignmentRule(JobStatus status)
        {
            this.status = status;
        }

        public string Message => "The just must have an assignment";

        public bool IsViolated() => !status.IsAssigned;
    }
}
