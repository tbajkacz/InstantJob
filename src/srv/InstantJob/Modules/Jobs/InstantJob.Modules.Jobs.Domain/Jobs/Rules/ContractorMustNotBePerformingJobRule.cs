using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class ContractorMustNotBePerformingJobRule : IDomainRule
    {
        private readonly Job job;
        private readonly Guid contractorId;

        public ContractorMustNotBePerformingJobRule(Job job, Guid contractorId)
        {
            this.job = job;
            this.contractorId = contractorId;
        }

        public string Message => "The contractor can't be in progress with this job";

        public bool IsViolated() => job.IsPerformedBy(contractorId);
    }
}
