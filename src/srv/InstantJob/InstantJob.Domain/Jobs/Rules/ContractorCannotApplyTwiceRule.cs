﻿using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Domain.Users.Entities;

namespace InstantJob.Domain.Jobs.Rules
{
    public class ContractorCannotApplyTwiceRule : IDomainRule
    {
        private readonly Job job;
        private readonly User contractor;

        public ContractorCannotApplyTwiceRule(Job job, User contractor)
        {
            this.job = job;
            this.contractor = contractor;
        }

        public string Message => "Each contractor may apply only once";

        public bool IsViolated() => job.HasApplied(contractor.Id);
    }
}
