using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using MediatR;
using System.Collections.Generic;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobStatuses
{
    public class GetJobStatusesQuery : IRequest<IEnumerable<JobStatus>>
    {
        
    }
}
