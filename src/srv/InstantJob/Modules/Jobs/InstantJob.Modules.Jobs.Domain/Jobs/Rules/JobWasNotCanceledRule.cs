using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Constants;

namespace InstantJob.Domain.Jobs.Rules
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
