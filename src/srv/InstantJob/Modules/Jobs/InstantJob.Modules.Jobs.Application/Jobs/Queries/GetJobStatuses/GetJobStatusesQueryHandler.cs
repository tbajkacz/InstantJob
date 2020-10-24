using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobStatuses
{
    public class GetJobStatusesQueryHandler : IRequestHandler<GetJobStatusesQuery, IEnumerable<JobStatus>>
    {
        public Task<IEnumerable<JobStatus>> Handle(GetJobStatusesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Enumeration.GetAll<JobStatus>());
        }
    }
}
