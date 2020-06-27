using MediatR;
using System;

namespace InstantJob.Core.Jobs.Commands.CancelJob
{
    public class CancelJobCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
