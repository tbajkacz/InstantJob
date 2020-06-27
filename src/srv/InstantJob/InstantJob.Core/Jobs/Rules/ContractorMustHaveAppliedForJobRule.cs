using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Jobs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.Core.Jobs.Rules
{
    public class ContractorMustHaveAppliedForJobRule : IDomainRule
    {
        private readonly IEnumerable<JobApplication> applications;
        private readonly int contractorId;

        public ContractorMustHaveAppliedForJobRule(IEnumerable<JobApplication> applications, int contractorId)
        {
            this.applications = applications;
            this.contractorId = contractorId;
        }

        public string Message => "A contractor must first apply, before being assigned to a job";

        public bool IsFailed() => !applications.Any(x => x.Contractor.Id == contractorId);
    }
}
