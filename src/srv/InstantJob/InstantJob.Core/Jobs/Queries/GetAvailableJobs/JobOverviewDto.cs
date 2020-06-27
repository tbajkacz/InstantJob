using AutoMapper;
using InstantJob.Core.Common.Mappings;
using InstantJob.Core.Jobs.Constants;
using InstantJob.Core.Jobs.Entities;
using System;

namespace InstantJob.Core.Jobs.Queries.GetAvailableJobs
{
    public class JobOverviewDto : IMapFrom<Job>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public DateTime PostedDate { get; set; }

        public Difficulty Difficulty { get; set; }

        public string CategoryName { get; set; }

        public JobOverviewUserDto Mandator { get; set; }

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<Job, JobOverviewDto>()
                .ForMember(x => x.CategoryName, mce => mce.MapFrom(x => x.Category.Name));
        }
    }
}
