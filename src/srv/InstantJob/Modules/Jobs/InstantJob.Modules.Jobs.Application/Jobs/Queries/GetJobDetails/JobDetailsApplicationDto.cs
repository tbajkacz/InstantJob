using System;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobDetails
{
    public class JobDetailsApplicationDto : IMapFrom<JobApplication>
    {
        public JobDetailsContractorDto Contractor { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}
