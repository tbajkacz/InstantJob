using System;
using AutoMapper;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Mandators;
using InstantJob.Modules.Jobs.Domain.Users;

namespace InstantJob.Modules.Jobs.Application.Queries.GetJobDetails
{
    public class JobDetailsContractorDto : IMapFrom<Contractor>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        //TODO FlattenedMap abstract class?
        public void CreateMap(Profile profile)
        {
            profile.CreateMap<JobUser, JobDetailsContractorDto>();

            profile.CreateMap<Mandator, JobDetailsContractorDto>()
                .AfterMap((m, dto, context) => context.Mapper.Map(m.JobUser, dto));
        }
    }
}
