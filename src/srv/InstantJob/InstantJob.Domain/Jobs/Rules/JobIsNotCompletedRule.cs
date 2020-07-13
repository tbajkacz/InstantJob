using InstantJob.Domain.Common;

namespace InstantJob.Domain.Jobs.Rules
{
    public class JobIsNotCompletedRule : IDomainRule
    {
        private readonly bool isCompleted;

        public JobIsNotCompletedRule(bool isCompleted)
        {
            this.isCompleted = isCompleted;
        }

        public string Message => "This job was already completed";

        public bool IsViolated() => isCompleted;
    }
}
