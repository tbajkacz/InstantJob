using InstantJob.Core.Common.Interfaces;

namespace InstantJob.Core.Jobs.Rules
{
    public class JobWasNotCanceledRule : IDomainRule
    {
        private readonly bool wasCanceled;

        public JobWasNotCanceledRule(bool wasCanceled)
        {
            this.wasCanceled = wasCanceled;
        }

        public string Message => "This job offer was canceled";

        public bool IsFailed() => wasCanceled;
    }
}
