using MediatR;
using System;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.CancelJobAssignment
{
    public class CancelJobAssignmentCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
