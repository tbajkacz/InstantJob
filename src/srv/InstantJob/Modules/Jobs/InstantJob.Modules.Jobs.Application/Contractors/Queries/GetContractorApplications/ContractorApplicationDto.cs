using System;

namespace InstantJob.Modules.Jobs.Application.Contractors.Queries.GetContractorApplications
{
    public class ContractorApplicationDto
    {
        public Guid JobId { get; set; }

        public string JobTitle { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}
