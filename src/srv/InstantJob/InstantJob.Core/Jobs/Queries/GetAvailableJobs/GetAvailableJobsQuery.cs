using MediatR;
using System.Collections.Generic;

namespace InstantJob.Core.Jobs.Queries.GetAvailableJobs
{
    public class GetAvailableJobsQuery : IRequest<IEnumerable<JobOverviewDto>>
    {
    }
}
