using MediatR;
using System.Collections.Generic;

namespace InstantJob.Core.Jobs.Queries.GetAvailableJobs
{
    public class GetAvailableJobsQuery : IRequest<IEnumerable<JobOverviewDto>>
    {
        public int? CategoryId { get; set; }

        public int? Skip { get; set; }

        public int? Count { get; set; }
    }
}
