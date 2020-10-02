using MediatR;
using System;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetContractorStatistics
{
    public class GetContractorStatisticsQuery : IRequest<GetContractorStatisticsDto>
    {
        public Guid? ContractorId { get; set; }
    }
}
