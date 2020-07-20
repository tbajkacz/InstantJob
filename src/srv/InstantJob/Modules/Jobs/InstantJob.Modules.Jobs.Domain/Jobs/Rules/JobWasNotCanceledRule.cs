using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class JobWasNotCanceledRule : IDomainRule
    {
        private readonly JobStatus status;

        public JobWasNotCanceledRule(JobStatus status)
        {
            this.status = status;
        }

        public string Message => "This job offer was canceled";

        public bool IsViolated() => status.IsCanceled;
    }
}
