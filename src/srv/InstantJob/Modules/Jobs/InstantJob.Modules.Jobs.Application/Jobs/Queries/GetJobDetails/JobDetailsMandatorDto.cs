using System;
using AutoMapper;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.JobUsers;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobDetails
{
    public class JobDetailsMandatorDto : IMapFrom<Mandator>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<JobUser, JobDetailsMandatorDto>();

            profile.CreateMap<Mandator, JobDetailsMandatorDto>()
                .AfterMap((m, dto, context) => context.Mapper.Map(m.JobUser, dto));
        }
    }
}
