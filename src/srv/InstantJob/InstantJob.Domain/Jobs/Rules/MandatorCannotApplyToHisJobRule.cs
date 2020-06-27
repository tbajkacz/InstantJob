using InstantJob.Domain.Common;
using System;

namespace InstantJob.Domain.Jobs.Rules
{
    public class MandatorCannotApplyToHisJobRule : IDomainRule
    {
        private readonly int mandatorId;
        private readonly int contractorId;

        public MandatorCannotApplyToHisJobRule(int mandatorId, int contractorId)
        {
            this.mandatorId = mandatorId;
            this.contractorId = contractorId;
        }

        public string Message => "A mandator may not apply to his own job";

        public bool IsFailed() => mandatorId == contractorId;
    }
}
