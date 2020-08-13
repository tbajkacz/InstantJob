using AutoMapper;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.JobUsers;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetAvailableJobs
{
    public class JobOverviewMandatorDto : IMapFrom<Mandator>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<JobUser, JobOverviewMandatorDto>();

            profile.CreateMap<Mandator, JobOverviewMandatorDto>()
                .AfterMap((m, dto, context) => context.Mapper.Map(m.JobUser, dto));
        }
    }
}
