using System;
using System.Collections.Generic;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Queries.GetAvailableJobs
{
    public class GetAvailableJobsQuery : IRequest<IEnumerable<JobOverviewDto>>
    {
        public Guid? CategoryId { get; set; }

        public int? Skip { get; set; }

        public int? Count { get; set; }
    }
}
