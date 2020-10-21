using InstantJob.Modules.Jobs.Application.Contractors.Queries.GetContractorApplications;
using InstantJob.Web.Api.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Authorize(Policies.Contractor)]
    [Route("api/contractors")]
    public class ContractorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContractorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Returns all contractors applications
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("applications")]
        [Authorize(Policies.Contractor)]
        public Task<IEnumerable<ContractorApplicationDto>> GetContractorApplications()
        {
            return mediator.Send(new GetContractorApplicationsQuery());
        }
    }
}
