using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Rules
{
    public class IsJobOwnerRule : IDomainRule
    {
        private readonly Job job;
        private readonly Guid mandatorId;

        public IsJobOwnerRule(Job job, Guid mandatorId)
        {
            this.job = job;
            this.mandatorId = mandatorId;
        }

        public bool IsViolated() => job.Mandator.Id != mandatorId;

        public string Message => "Unauthorized resource access";
    }
}
