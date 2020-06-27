﻿using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Jobs.Entities;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.Core.Jobs.Rules
{
    public class ContractorCannotApplyTwiceRule : IDomainRule
    {
        private readonly IEnumerable<JobApplication> applications;
        private readonly int contractorId;

        public ContractorCannotApplyTwiceRule(IEnumerable<JobApplication> applications, int contractorId)
        {
            this.applications = applications;
            this.contractorId = contractorId;
        }

        public string Message => "Each contractor may apply only once";

        public bool IsFailed() => applications.Any(x => x.Contractor.Id == contractorId);
    }
}