using System;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Modules.Jobs.Application.Queries.GetJobDetails
{
    public class JobDetailsMandatorDto : IMapFrom<Mandator>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
