using InstantJob.Modules.Jobs.Application.Jobs.Queries.GetContractorStatistics;
using InstantJob.Modules.Jobs.Application.Jobs.Queries.GetMandatorStatistics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StatisticsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("mandator/{id}")]
        public Task<GetMandatorStatisticsDto> GetMandatorStatistics(Guid? id)
        {
            return mediator.Send(new GetMandatorStatisticsQuery { MandatorId = id });
        }

        [HttpGet("contractor/{id}")]
        public Task<GetContractorStatisticsDto> GetContractorStatistics(Guid? id)
        {
            return mediator.Send(new GetContractorStatisticsQuery { ContractorId = id });
        }
    }
}
