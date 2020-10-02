using MediatR;
using System;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetMandatorStatistics
{
    public class GetMandatorStatisticsQuery : IRequest<GetMandatorStatisticsDto>
    {
        public Guid? MandatorId { get; set; }
    }
}
