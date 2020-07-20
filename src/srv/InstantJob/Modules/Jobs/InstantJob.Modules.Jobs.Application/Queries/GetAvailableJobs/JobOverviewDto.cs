using System;
using AutoMapper;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Application.Queries.GetAvailableJobs
{
    public class JobOverviewDto : IMapFrom<Job>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public DateTime PostedDate { get; set; }

        public Difficulty Difficulty { get; set; }

        public string CategoryName { get; set; }

        public JobOverviewMandatorDto Mandator { get; set; }

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<Job, JobOverviewDto>()
                .ForMember(x => x.CategoryName, mce => mce.MapFrom(x => x.Category.Name));
        }
    }
}
