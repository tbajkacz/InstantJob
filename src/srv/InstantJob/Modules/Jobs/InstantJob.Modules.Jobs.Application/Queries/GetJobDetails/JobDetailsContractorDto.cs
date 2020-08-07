using System;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Contractors;

namespace InstantJob.Modules.Jobs.Application.Queries.GetJobDetails
{
    public class JobDetailsContractorDto : IMapFrom<Contractor>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
