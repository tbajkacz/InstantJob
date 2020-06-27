using MediatR;
using System;

namespace InstantJob.Core.Jobs.Commands.CompleteJob
{
    public class CompleteJobCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
