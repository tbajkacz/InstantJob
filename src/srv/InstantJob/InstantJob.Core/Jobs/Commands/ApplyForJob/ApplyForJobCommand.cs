using MediatR;
using System;

namespace InstantJob.Core.Jobs.Commands.ApplyForJob
{
    public class ApplyForJobCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
