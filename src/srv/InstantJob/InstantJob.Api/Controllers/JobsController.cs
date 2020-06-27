using InstantJob.Core.Jobs.Commands.ApplyForJob;
using InstantJob.Core.Jobs.Commands.AssignContractor;
using InstantJob.Core.Jobs.Commands.CancelJob;
using InstantJob.Core.Jobs.Commands.CompleteJob;
using InstantJob.Core.Jobs.Commands.PostJob;
using InstantJob.Core.Jobs.Commands.UpdateJobDetails;
using InstantJob.Core.Jobs.Queries.GetAvailableJobs;
using InstantJob.Core.Jobs.Queries.GetJobDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstantJob.Api.Controllers
{
    [Authorize]
    public class JobsController : RoutedApiController
    {
        private readonly IMediator mediator;

        public JobsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<JobOverviewDto>> GetAvailableJobs()
        {
            return await mediator.Send(new GetAvailableJobsQuery());
        }

        [HttpGet("{id}")]
        public async Task<JobDetailsDto> GetJobDetails(Guid id)
        {
            return await mediator.Send(new GetJobDetailsQuery(id));
        }

        [HttpPost]
        public async Task PostJob(PostJobCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateJobDetails(UpdateJobDetailsCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPost]
        public async Task ApplyForJob(ApplyForJobCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPut]
        public async Task AssignContractor(AssignContractorCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPut]
        public async Task CancelJob(CancelJobCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPut]
        public async Task CompleteJob(CompleteJobCommand command)
        {
            await mediator.Send(command);
        }
    }
}
