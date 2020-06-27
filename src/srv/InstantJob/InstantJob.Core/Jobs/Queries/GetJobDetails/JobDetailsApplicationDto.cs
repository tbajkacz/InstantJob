using InstantJob.Core.Common.Mappings;
using InstantJob.Core.Jobs.Entities;
using System;

namespace InstantJob.Core.Jobs.Queries.GetJobDetails
{
    public class JobDetailsApplicationDto : IMapFrom<JobApplication>
    {
        public JobDetailsUserDto Contractor { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}
