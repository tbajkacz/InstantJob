using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.CancelJob
{
    public class CancelJobCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
