using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Modules.Jobs.Application.Queries.GetAvailableJobs
{
    public class JobOverviewMandatorDto : IMapFrom<Mandator>
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
