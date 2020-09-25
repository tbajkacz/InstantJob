using AutoMapper;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using System;

namespace InstantJob.Modules.Jobs.Application.Contractors.Queries.GetContractorJobsInfo
{
    public class ContractorJobsInfoJobDto : IMapFrom<Job>
    {
        public Guid JobId { get; set; }

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<Job, ContractorJobsInfoJobDto>()
                .ForMember(d => d.JobId, mce => mce.MapFrom(j => j.Id));
        }
    }
}
