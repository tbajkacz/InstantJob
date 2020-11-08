using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using MediatR;
using System.Collections.Generic;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.SeedJobs
{
    public class SeedJobsCommand : IRequest
    {
        public List<Job> Jobs{ get; set; }
    }
}
