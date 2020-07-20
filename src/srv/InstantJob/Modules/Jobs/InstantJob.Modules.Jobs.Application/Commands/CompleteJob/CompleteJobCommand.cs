using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.CompleteJob
{
    public class CompleteJobCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
