﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.AcceptJobAssignment;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.ApplyForJob;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.AssignContractor;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.CancelJob;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.CompleteJob;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.PostJob;
using InstantJob.Modules.Jobs.Application.Jobs.Commands.UpdateJobDetails;
using InstantJob.Modules.Jobs.Application.Jobs.Queries.GetAvailableJobs;
using InstantJob.Modules.Jobs.Application.Jobs.Queries.GetDifficulties;
using InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobDetails;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Web.Api.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets jobs which contractors can apply to
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<JobOverviewDto>> GetAvailableJobs([FromQuery] GetAvailableJobsQuery query)
        {
            return await mediator.Send(query);
        }

        /// <summary>
        /// Gets single job details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<JobDetailsDto> GetJobDetails(Guid id)
        {
            return await mediator.Send(new GetJobDetailsQuery(id));
        }

        /// <summary>
        /// Adds a new job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policies.Mandator)]
        public async Task PostJob(PostJobCommand command)
        {
            await mediator.Send(command);
        }

        /// <summary>
        /// Updates job information
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [Authorize(Policies.Mandator)]
        public async Task UpdateJobDetails(UpdateJobDetailsCommand command, Guid id)
        {
            //TODO custom model binder?
            command.JobId = id;
            await mediator.Send(command);
        }

        /// <summary>
        /// Adds an application for a contractor to the specified job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("{id}/applications/apply")]
        [Authorize(Policies.Contractor)]
        public async Task ApplyForJob(ApplyForJobCommand command, Guid id)
        {
            command.JobId = id;
            await mediator.Send(command);
        }

        /// <summary>
        /// Assigns a contractor to the specified job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}/assignment/assign")]
        [Authorize(Policies.Mandator)]
        public async Task AssignContractor(AssignContractorCommand command, Guid id)
        {
            command.JobId = id;
            await mediator.Send(command);
        }

        /// <summary>
        /// Accepts the specified assigned job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}/assignment/accept")]
        [Authorize(Policies.Contractor)]
        public async Task AcceptJobAssignment(AcceptJobAssignmentCommand command, Guid id)
        {
            command.JobId = id;
            await mediator.Send(command);
        }

        /// <summary>
        /// Cancels the specified job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}/cancel")]
        [Authorize(Policies.Mandator)]
        public async Task CancelJob(CancelJobCommand command, Guid id)
        {
            command.JobId = id;
            await mediator.Send(command);
        }

        /// <summary>
        /// Completes the specified job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("{id}/complete")]
        [Authorize(Policies.Mandator)]
        public async Task CompleteJob(CompleteJobCommand command, Guid id)
        {
            command.JobId = id;
            await mediator.Send(command);
        }

        /// <summary>
        /// Gets available job difficulties
        /// </summary>
        /// <returns></returns>
        [HttpGet("difficulties")]
        public async Task<IEnumerable<Difficulty>> GetDifficulties()
        {
            return await mediator.Send(new GetDifficultiesQuery());
        }
    }
}
