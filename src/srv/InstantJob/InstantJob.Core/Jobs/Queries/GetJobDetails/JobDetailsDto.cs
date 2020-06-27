using AutoMapper;
using InstantJob.Core.Common.Mappings;
using InstantJob.Core.Jobs.Constants;
using InstantJob.Core.Jobs.Entities;
using System;
using System.Collections.Generic;

namespace InstantJob.Core.Jobs.Queries.GetJobDetails
{
    public class JobDetailsDto : IMapFrom<Job>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<JobDetailsApplicationDto> Applications { get; set; }

        public decimal? Price { get; set; }

        public DateTime PostedDate { get; set; }

        public DateTime Deadline { get; set; }

        public Difficulty Difficulty { get; set; }

        public bool WasCanceled { get; set; }

        public string CategoryName { get; set; }

        public JobDetailsUserDto Mandator { get; set; }

        public JobDetailsUserDto Contractor { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsInProgress { get; set; }

        public void CreateMap(Profile profile)
        {
            profile.CreateMap<Job, JobDetailsDto>()
                .ForMember(x => x.CategoryName, mce => mce.MapFrom(x => x.Category.Name));
        }
    }
}
