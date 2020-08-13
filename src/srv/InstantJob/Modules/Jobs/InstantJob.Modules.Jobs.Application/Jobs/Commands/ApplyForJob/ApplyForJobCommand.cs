using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.ApplyForJob
{
    public class ApplyForJobCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
