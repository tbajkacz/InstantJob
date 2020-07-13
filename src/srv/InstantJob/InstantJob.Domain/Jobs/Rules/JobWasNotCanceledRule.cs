using InstantJob.Domain.Common;

namespace InstantJob.Domain.Jobs.Rules
{
    public class JobWasNotCanceledRule : IDomainRule
    {
        private readonly bool wasCanceled;

        public JobWasNotCanceledRule(bool wasCanceled)
        {
            this.wasCanceled = wasCanceled;
        }

        public string Message => "This job offer was canceled";

        public bool IsViolated() => wasCanceled;
    }
}
