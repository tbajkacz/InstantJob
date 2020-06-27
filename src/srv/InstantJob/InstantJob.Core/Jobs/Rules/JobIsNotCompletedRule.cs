using InstantJob.Core.Common.Interfaces;
using System;

namespace InstantJob.Core.Jobs.Rules
{
    public class JobIsNotCompletedRule : IDomainRule
    {
        private readonly bool isCompleted;

        public JobIsNotCompletedRule(bool isCompleted)
        {
            this.isCompleted = isCompleted;
        }

        public string Message => "This job was already completed";

        public bool IsFailed() => isCompleted;
    }
}
