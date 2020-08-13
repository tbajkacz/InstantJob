using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.AcceptJobAssignment
{
    public class AcceptJobAssignmentCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
